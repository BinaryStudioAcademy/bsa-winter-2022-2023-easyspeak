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

    /**
     * WebRTC peer connection utils
     */
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

    /**
     * represents a candidate Interactive Connectivity Establishment (ICE) configuration which may be used to
     * establish an RTCPeerConnection.
     */
    public static doIceRestart(peerConnection: RTCPeerConnection, messageSender: MessageSender): void {
        try {
            // try using new restartIce method
            peerConnection.restartIce();
        } catch (error) {
            // if it is not supported, use the old implementation
            peerConnection.createOffer({
                iceRestart: true,
            })
                .then((sessionDescription: RTCSessionDescriptionInit) => {
                    peerConnection.setLocalDescription(sessionDescription);
                    messageSender.sendMessage(sessionDescription);
                });
        }
    }

    /**
     * WebRTC starts reports
     * @param peerConnection - local and remote user connection
     */
    public static logStats(peerConnection: RTCPeerConnection): void {
        peerConnection.getStats().then(stat => {
            stat.forEach(console.info);
        });
    }

    /**
     * WebRTC bitrate manipulation
     */
    public static changeBitrate(
        sessionDescription: RTCSessionDescriptionInit,
        start: string,
        min: string,
        max: string,
    ): RTCSessionDescription {
        const sessionDescriptionLines = sessionDescription.sdp?.split('\r\n');

        sessionDescriptionLines?.forEach((str, i) => {
            // use only relevant lines
            if (str.indexOf('a=fmtp') !== -1) {
                // if bitrates are not yet set, create required lines and set them, otherwise change them to new values
                if (str.indexOf('x-google-') === -1) {
                    sessionDescriptionLines[i] =
                        `${str};x-google-max-bitrate=${max};x-google-min-bitrate=${min};x-google-start-bitrate=${start}`;
                } else {
                    sessionDescriptionLines[i] = `${str.split(
                        ';x-google-',
                    )[0]};x-google-max-bitrate=${max};x-google-min-bitrate=${min};x-google-start-bitrate=${start}`;
                }
            }
        });

        return new RTCSessionDescription({
            type: sessionDescription.type,
            sdp: sessionDescriptionLines?.join('\r\n'),
        });
    }

    /**
     * WebRTC's codecs manipulation
     */
    public static getCodecs(type: 'audio' | 'video'): string[] {
        return RTCRtpSender.getCapabilities(type)?.codecs
            .map(c => c.mimeType)
            .filter((value, index, self) => self.indexOf(value) === index)
            ?? [];
    }

    public static setCodecs(
        sessionDescription: RTCSessionDescriptionInit,
        type: 'audio' | 'video',
        codecMimeType: string,
    ): RTCSessionDescriptionInit {
        const sdpLines = sessionDescription.sdp!.split('\r\n');

        sdpLines.forEach((str, i) => {
            // use only relevant type SDP lines
            if (str.startsWith(`m=${type}`)) {
                const lineWords = str.split(' ');
                // get all lines (payloads) related to given codec
                const payloads = this.getPayloads(sessionDescription.sdp!, codecMimeType);
                // proceed only with relevant payloads for this specific sdp line
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
            type: sessionDescription.type,
            sdp: sdpLines.join('\r\n'),
        });
    }

    private static getPayloads(sessionDescription: string, codec: string): string[] {
        const payloads: string[] = [];
        const sdpLines = sessionDescription.split('\r\n');

        sdpLines.forEach((str) => {
            if (str.indexOf('a=rtpmap:') !== -1 && str.indexOf(codec) !== -1) {
                payloads.push(str.split('a=rtpmap:').pop()!.split(' ')[0]);
            }
        });

        return payloads.filter((p, i) => payloads.indexOf(p) === i);
    }
}
