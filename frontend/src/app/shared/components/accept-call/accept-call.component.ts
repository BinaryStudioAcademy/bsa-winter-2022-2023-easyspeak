import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';
import { SessionCallComponent } from '@modules/session-call/session-call/session-call.component';
import { ICallInfo } from '@shared/models/chat/ICallInfo';
import { IUserShort } from '@shared/models/IUserShort';

@Component({
    selector: 'app-accept-call',
    templateUrl: './accept-call.component.html',
    styleUrls: ['./accept-call.component.sass'],
})
export class AcceptCallComponent implements OnInit {
    constructor(
        @Inject(MAT_DIALOG_DATA) public callInfo: ICallInfo,
        private router: Router,
        private webRtcHub: WebrtcHubService,
        private dialogRef: MatDialog,
    ) {}

    user: IUserShort;

    remoteFullName: string;

    remoteImgPath: string | undefined;

    ngOnInit(): void {
        this.user = JSON.parse(localStorage.getItem('user') as string);
        this.remoteFullName = this.callInfo.remoteName;
        this.remoteImgPath = this.callInfo.remoteImgPath;
    }

    async answerCall() {
        const fullName = `${this.user.firstName} ${this.user.lastName}`;

        await this.webRtcHub.acceptCall(
            this.callInfo.chatId,
            this.callInfo.callerId,
            this.callInfo.remoteEmail,
            this.user.email,
            fullName,
            this.callInfo.roomName,
        );

        const config: MatDialogConfig<ICallInfo> = {
            minWidth: '100vw',
            data: {
                chatId: this.callInfo.chatId,
                callerId: this.callInfo.callerId,
                roomName: this.callInfo.roomName,
                remoteEmail: this.callInfo.remoteEmail,
                remoteName: this.callInfo.remoteName,
            },
        };

        this.dialogRef.open(SessionCallComponent, config);
    }

    async rejectCall() {
        await this.webRtcHub.rejectCall(this.callInfo.remoteEmail);
    }
}
