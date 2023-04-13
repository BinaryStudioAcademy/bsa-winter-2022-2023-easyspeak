import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { SessionCallComponent } from '@modules/session-call/session-call/session-call.component';
import { AcceptCallComponent } from '@shared/components/accept-call/accept-call.component';
import { IAcceptCallInfo } from '@shared/models/chat/IAcceptCallInfo';
import { ICallInfo } from '@shared/models/chat/ICallInfo';
import { ICallUserInfo } from '@shared/models/chat/ICallUserInfo';
import { Subject, Subscription } from 'rxjs';

import { NotificationService } from 'src/app/services/notification.service';

import { WebrtcHubFactoryService } from './hubFactories/webrtc-hub-factory.service';

@Injectable({
    providedIn: 'root',
})
export class WebrtcHubService {
    readonly hubUrl = 'signaling';

    private hubConnection: HubConnection;

    readonly messages = new Subject<string>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: WebrtcHubFactoryService, private dialogRef: MatDialog, private toastr: NotificationService) {}

    async start() {
        if (!this.hubConnection || this.hubConnection.state === HubConnectionState.Disconnected) {
            this.hubConnection = this.hubFactory.createHub(this.hubUrl);
            await this.init();
        }
    }

    /* eslint-disable  @typescript-eslint/no-explicit-any */
    listenMessages(action: (msg: any) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    disconnect(): void {
        if (this.isConnected()) {
            this.hubConnection.stop();
        }
        this.subscriptions.forEach((s) => s.unsubscribe());
    }

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('log', (msg: string) => {
            this.messages.next(msg);
        });

        this.hubConnection.on('created', () => {
            this.messages.next('created');
        });

        this.hubConnection.on('joined', () => {
            this.messages.next('joined');
        });

        this.hubConnection.on('message', (msg: string) => {
            this.messages.next(msg);
        });

        this.hubConnection.on(
            'startCall',
            (
                chatId: number,
                callerId: number,
                callerEmail: string,
                callerFullName: string,
                callerImgPath: string,
                roomName: string,
            ) => {
                const config: MatDialogConfig<ICallInfo> = {
                    data: {
                        hasButtons: true,
                        chatId,
                        callerId,
                        roomName,
                        remoteEmail: callerEmail,
                        remoteName: callerFullName,
                        remoteImgPath: callerImgPath,
                    },
                };

                this.dialogRef.open(AcceptCallComponent, config);
            },
        );

        this.hubConnection.on(
            'accept',
            (chatId: number, callerId: number, calleeEmail: string, calleeFullName: string, roomName: string) => {
                const config: MatDialogConfig<ICallInfo> = {
                    minWidth: '100vw',
                    data: {
                        hasButtons: true,
                        chatId,
                        callerId,
                        roomName,
                        remoteEmail: calleeEmail,
                        remoteName: calleeFullName,
                    },
                };

                this.dialogRef.closeAll();
                this.dialogRef.open(SessionCallComponent, config);
            },
        );

        this.hubConnection.on('reject', () => {
            this.dialogRef.closeAll();
        });

        this.hubConnection.on('endCall', () => {
            this.dialogRef.closeAll();
        });
    }

    public async connect(email: string) {
        await this.hubConnection.invoke('Connect', email).catch((err) => {
            this.toastr.showError(err, 'Error!');
        });
    }

    public async disconnectUser(email: string) {
        await this.hubConnection.invoke('Disconnect', email).catch((err) => {
            this.toastr.showError(err, 'Error!');
        });
    }

    public async callUser(callInfo: ICallUserInfo) {
        await this.hubConnection
            .invoke(
                'CallUser',
                callInfo.chatId,
                callInfo.calleeEmail,
                callInfo.callerId,
                callInfo.callerEmail,
                callInfo.callerFullName,
                callInfo.callerImgPath,
            )
            .catch((err) => {
                this.toastr.showError(err, 'Error!');
            });
    }

    public async acceptCall(callInfo: IAcceptCallInfo) {
        await this.hubConnection
            .invoke(
                'AcceptCall',
                callInfo.chatId,
                callInfo.callerId,
                callInfo.callerEmail,
                callInfo.calleeEmail,
                callInfo.calleeFullName,
                callInfo.roomName,
            )
            .catch((err) => {
                this.toastr.showError(err, 'Error!');
            });
    }

    public async rejectCall(email: string) {
        await this.hubConnection.invoke('RejectCall', email).catch((err) => {
            this.toastr.showError(err, 'Error!');
        });
    }

    public async endCall(chatId: number, userId: number, startedAt: Date, finishedAt: Date) {
        await this.hubConnection.invoke('EndCall', chatId, userId, startedAt, finishedAt).catch((err) => {
            this.toastr.showError(err, 'Error!');
        });
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
