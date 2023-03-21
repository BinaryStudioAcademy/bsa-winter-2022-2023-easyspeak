import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';
import { WebrtcUtils } from '@core/services/webrtc-utils.service';
import { environment } from '@env/environment';

const useWebrtcUtils = true;

@Component({
    selector: 'app-session-call',
    templateUrl: './session-call.component.html',
    styleUrls: ['./session-call.component.sass'],
})
export class SessionCallComponent implements OnInit, OnDestroy {
    @ViewChild('localVideo') localVideo: ElementRef;

    @ViewChild('remoteVideo') remoteVideo: ElementRef;

    localStream: MediaStream;

    remoteStream: MediaStream;

    room: string;

    peerConnection: RTCPeerConnection;

    isInitiator: boolean;

    isChannelReady: boolean;

    isStarted: boolean;

    public constructor(
        private webrtcHub: WebrtcHubService,
        private snack: MatSnackBar,
        private route: ActivatedRoute,
    ) {
        this.route.paramMap.subscribe(async param => {
            this.room = param.get('room')!;
        });
    }

    async ngOnInit() {
        await this.webrtcHub.start();
        this.webrtcHub.invoke('CreateOrJoinRoom', this.room);
        this.webrtcHub.listenMessages((msg) => {
            if (msg === 'created') {
                this.isInitiator = true;
            }
            if (msg === 'joined') {
                this.isChannelReady = true;
            }
            if (msg === 'got user media') {
                this.initiateCall();
            } else if (msg.type === 'offer') {
                if (!this.isStarted) {
                    this.initiateCall();
                }
                this.peerConnection.setRemoteDescription(new RTCSessionDescription(msg));
                this.sendAnswer();
            } else if (msg.type === 'answer' && this.isStarted) {
                this.peerConnection.setRemoteDescription(new RTCSessionDescription(msg));
            } else if (msg.type === 'candidate' && this.isStarted) {
                this.addIceCandidate(msg);
            } else if (msg === 'bye' && this.isStarted) {
                this.handleRemoteHangup();
            }
        });

        // #3 get media from current client
        this.getUserMedia();
    }

    async ngOnDestroy() {
        await this.hangup();
        if (this.localStream && this.localStream.active) {
            this.localStream.getTracks().forEach((track) => { track.stop(); });
        }
        if (this.remoteStream && this.remoteStream.active) {
            this.remoteStream.getTracks().forEach((track) => { track.stop(); });
        }
    }

    getUserMedia(): void {
        navigator.mediaDevices.getUserMedia({
            audio: true,
            video: true,
        })
            .then((stream: MediaStream) => {
                this.addLocalStream(stream);
                this.sendMessage('got user media');
                if (this.isInitiator) {
                    this.initiateCall();
                }
            })
            .catch((e) => {
                console.error(`getUserMedia() error: ${e.name}: ${e.message}`);
            });
    }

    initiateCall(): void {
        if (!this.isStarted && this.localStream && this.isChannelReady) {
            this.createPeerConnection();

            this.peerConnection.addTrack(this.localStream.getVideoTracks()[0], this.localStream);
            this.peerConnection.addTrack(this.localStream.getAudioTracks()[0], this.localStream);
            this.isStarted = true;
            if (this.isInitiator) {
                this.sendOffer();
            }
        }
    }

    createPeerConnection(): void {
        try {
            if (useWebrtcUtils) {
                this.peerConnection =
                    WebrtcUtils.createPeerConnection(environment.iceServers, 'unified-plan', 'balanced', 'all', 'require', null!, [], 0);
            } else {
                this.peerConnection = new RTCPeerConnection({
                    iceServers: environment.iceServers,
                    sdpSemantics: 'unified-plan',
                } as RTCConfiguration);
            }

            this.peerConnection.onicecandidate = (event: RTCPeerConnectionIceEvent) => {
                if (event.candidate) {
                    this.sendIceCandidate(event);
                }
            };

            this.peerConnection.ontrack = (event: RTCTrackEvent) => {
                if (event.streams[0]) {
                    this.addRemoteStream(event.streams[0]);
                }
            };

            if (useWebrtcUtils) {
                this.peerConnection.oniceconnectionstatechange = () => {
                    if (this.peerConnection?.iceConnectionState === 'connected') {
                        WebrtcUtils.logStats(this.peerConnection, 'all');
                    } else if (this.peerConnection?.iceConnectionState === 'failed') {
                        WebrtcUtils.doIceRestart(this.peerConnection, this);
                    }
                };
            }
        } catch (e: unknown) {
            console.error('Failed to create PeerConnection.');
        }
    }

    sendOffer(): void {
        this.addTransceivers();
        this.peerConnection.createOffer()
            .then((sdp: RTCSessionDescriptionInit) => {
                let finalSdp = sdp;

                if (useWebrtcUtils) {
                    finalSdp = WebrtcUtils.changeBitrate(sdp, '1000', '500', '6000');
                    if (WebrtcUtils.getCodecs('audio').find(c => c.indexOf(WebrtcUtils.OPUS) !== -1)) {
                        finalSdp = WebrtcUtils.setCodecs(finalSdp, 'audio', WebrtcUtils.OPUS);
                    }
                    if (WebrtcUtils.getCodecs('video').find(c => c.indexOf(WebrtcUtils.H264) !== -1)) {
                        finalSdp = WebrtcUtils.setCodecs(finalSdp, 'video', WebrtcUtils.H264);
                    }
                }
                this.peerConnection.setLocalDescription(finalSdp);
                this.sendMessage(sdp);
            });
    }

    sendAnswer(): void {
        this.addTransceivers();
        this.peerConnection.createAnswer().then((sdp) => {
            this.peerConnection.setLocalDescription(sdp);
            this.sendMessage(sdp);
        });
    }

    addIceCandidate(message: { label?: number, candidate?: string }): void {
        const candidate = new RTCIceCandidate({
            sdpMLineIndex: message.label,
            candidate: message.candidate,
        });

        this.peerConnection.addIceCandidate(candidate);
    }

    sendIceCandidate(event: RTCPeerConnectionIceEvent): void {
        this.sendMessage({
            type: 'candidate',
            label: event.candidate?.sdpMLineIndex,
            id: event.candidate?.sdpMid,
            candidate: event.candidate?.candidate,
        });
    }

    async sendMessage(message: unknown): Promise<void> {
        await this.webrtcHub.invoke('SendMessage', message, this.room);
    }

    addTransceivers(): void {
        const init = { direction: 'recvonly', streams: [], sendEncodings: [] } as RTCRtpTransceiverInit;

        this.peerConnection.addTransceiver('audio', init);
        this.peerConnection.addTransceiver('video', init);
    }

    addLocalStream(stream: MediaStream): void {
        this.localStream = stream;
        this.localVideo.nativeElement.srcObject = this.localStream;
        this.localVideo.nativeElement.muted = 'muted';
    }

    addRemoteStream(stream: MediaStream): void {
        this.remoteStream = stream;
        this.remoteVideo.nativeElement.srcObject = this.remoteStream;
        this.remoteVideo.nativeElement.muted = 'muted';
    }

    async hangup(): Promise<void> {
        this.stopPeerConnection();
        this.sendMessage('bye');
        await this.webrtcHub.invoke('LeaveRoom', this.room);
        setTimeout(() => {
            this.webrtcHub.disconnect();
        }, 1000);
    }

    handleRemoteHangup(): void {
        this.stopPeerConnection();
        this.isInitiator = true;
        this.snack.open('Remote client has left the call.', 'Dismiss', { duration: 5000 });
    }

    stopPeerConnection(): void {
        this.isStarted = false;
        this.isChannelReady = false;
        if (this.peerConnection) {
            this.peerConnection.close();
            this.peerConnection = null!;
        }
    }

    toggleTrack(type: string) {
        this.localStream.getTracks().forEach((track) => {
            if (track.kind === type) {
                track.enabled = !track.enabled;
            }
        });
    }
}
