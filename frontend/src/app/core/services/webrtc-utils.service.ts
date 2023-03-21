import { Injectable } from '@angular/core';

export interface MessageSender {
    sendMessage(message: unknown): void;
}

@Injectable({
    providedIn: 'root',
})
export class WebrtcUtils {
    public static readonly OPUS = 'opus';

    public static readonly H264 = 'H264';

    public static createPeerConnection(
        iceServers: RTCIceServer[],
        sdpSemantics: 'unified-plan' | 'plan-b',
        bundlePolicy: RTCBundlePolicy,
        iceTransportPolicy: RTCIceTransportPolicy,
        rtcpMuxPolicy: RTCRtcpMuxPolicy,
        peerIdentity: string,
        certificates: RTCCertificate[],
        iceCandidatePoolSize: number,
    ): RTCPeerConnection {
        return new RTCPeerConnection({
            iceServers, sdpSemantics, bundlePolicy, iceTransportPolicy, rtcpMuxPolicy, peerIdentity, certificates, iceCandidatePoolSize,
        } as RTCConfiguration);
    }

    public static doIceRestart(peerConnection: RTCPeerConnection, messageSender: MessageSender): void {
        try {
            // try using new restartIce method
            peerConnection.restartIce();
        } catch (error) {
            // if it is not supported, use the old implementation
            peerConnection.createOffer({
                iceRestart: true,
            })
                .then((sdp: RTCSessionDescriptionInit) => {
                    peerConnection.setLocalDescription(sdp);
                    messageSender.sendMessage(sdp);
                });
        }
    }

    public static logStats(peerConnection: RTCPeerConnection, type: 'inbound' | 'outbound' | 'all'): void {
        peerConnection.getStats().then(stat => {
            stat.forEach(report => {
                switch (type) {
                    case 'inbound':
                        if (report.type === 'inbound-rtp') {
                            console.info(report);
                        }
                        break;
                    case 'outbound':
                        if (report.type === 'outbound-rtp') {
                            console.info(report);
                        }
                        break;
                    default:
                        console.info(report);
                }
            });
        });
    }

    public static changeBitrate(sdp: RTCSessionDescriptionInit, start: string, min: string, max: string): RTCSessionDescription {
        const sdpLines = sdp.sdp?.split('\r\n');

        sdpLines?.forEach((str, i) => {
            // use only relevant lines
            if (str.indexOf('a=fmtp') !== -1) {
                // if bitrates are not yet set, create required lines and set them, otherwise change them to new values
                if (str.indexOf('x-google-') === -1) {
                    sdpLines[i] = `${str};x-google-max-bitrate=${max};x-google-min-bitrate=${min};x-google-start-bitrate=${start}`;
                } else {
                    sdpLines[i] = `${str.split(
                        ';x-google-',
                    )[0]};x-google-max-bitrate=${max};x-google-min-bitrate=${min};x-google-start-bitrate=${start}`;
                }
            }
        });

        return new RTCSessionDescription({
            type: sdp.type,
            sdp: sdpLines?.join('\r\n'),
        });
    }

    public static getCodecs(type: 'audio' | 'video'): string[] {
        return RTCRtpSender.getCapabilities(type)?.codecs
            .map(c => c.mimeType)
            .filter((value, index, self) => self.indexOf(value) === index)
            ?? [];
    }

    public static setCodecs(sdp: RTCSessionDescriptionInit, type: 'audio' | 'video', codecMimeType: string): RTCSessionDescriptionInit {
        const sdpLines = sdp.sdp!.split('\r\n');

        sdpLines.forEach((str, i) => {
            // use only relevant type SDP lines
            if (str.startsWith(`m=${type}`)) {
                const lineWords = str.split(' ');
                // get all lines (payloads) related to given codec
                const payloads = this.getPayloads(sdp.sdp!, codecMimeType);
                // proceed only with relavant payloads for this specific sdp line
                const relevantPayloads = payloads.filter(p => lineWords.indexOf(p) !== -1);

                if (relevantPayloads.length > 0) {
                    // remove the codecs from current positions in the line
                    relevantPayloads.forEach(codec => {
                        const index = lineWords.indexOf(codec, 2);

                        lineWords.splice(index, 1);
                    });
                    // add first three default values (M=, #, protocols)
                    let newStr = `${lineWords[0]} ${lineWords[1]} ${lineWords[2]}`;

                    // add chosen codecs on the beginning
                    relevantPayloads.forEach(codec => {
                        newStr = `${newStr} ${codec}`;
                    });
                    // add the rest of codecs on the end
                    for (let k = 3; k < lineWords.length; k++) {
                        newStr = `${newStr} ${lineWords[k]}`;
                    }
                }
                sdpLines[i] = str;
            }
        });

        // create new SDP with changed codecs
        return new RTCSessionDescription({
            type: sdp.type,
            sdp: sdpLines.join('\r\n'),
        });
    }

    private static getPayloads(sdp: string, codec: string): string[] {
        const payloads: string[] = [];
        const sdpLines = sdp.split('\r\n');

        sdpLines.forEach((str) => {
            if (str.indexOf('a=rtpmap:') !== -1 && str.indexOf(codec) !== -1) {
                payloads.push(str.split('a=rtpmap:').pop()!.split(' ')[0]);
            }
        });

        return payloads.filter((v, i) => payloads.indexOf(v) === i);
    }
}