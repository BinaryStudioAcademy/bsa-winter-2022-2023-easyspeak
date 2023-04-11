import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { SessionCallComponent } from '@modules/session-call/session-call/session-call.component';
import { AcceptCallComponent } from '@shared/components/accept-call/accept-call.component';
import { ICallInfo } from '@shared/models/chat/ICallInfo';
import { Subject, Subscription } from 'rxjs';

import { WebrtcHubFactoryService } from './hubFactories/webrtc-hub-factory.service';

@Injectable({
    providedIn: 'root',
})
export class WebrtcHubService {
    readonly hubUrl = 'signaling';

    private hubConnection: HubConnection;

    readonly messages = new Subject<string>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: WebrtcHubFactoryService, private dialogRef: MatDialog, private router: Router) {}

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

        this.hubConnection.on('startCall', (callerEmail: string, callerFullName: string, callerImgPath: string, roomName: string) => {
            const config: MatDialogConfig<ICallInfo> = {
                data: {
                    roomName,
                    remoteEmail: callerEmail,
                    remoteName: callerFullName,
                    remoteImgPath: callerImgPath,
                },
            };

            this.dialogRef.open(AcceptCallComponent, config);
        });

        this.hubConnection.on('accept', (calleeEmail: string, calleeFullName: string, roomName: string) => {
            const config: MatDialogConfig<ICallInfo> = {
                data: {
                    roomName,
                    remoteEmail: calleeEmail,
                    remoteName: calleeFullName,
                },
            };

            this.dialogRef.open(SessionCallComponent, config);
        });

        this.hubConnection.on('reject', () => {
            this.messages.next('Rejected');
        });

        this.hubConnection.on('endCall', () => {
            this.dialogRef.closeAll();
        });
    }

    public async connect(email: string) {
        await this.hubConnection.invoke('Connect', email).catch((err) => {
            console.error(err);
        });
    }

    public async disconnectUser(email: string) {
        await this.hubConnection.invoke('Disconnect', email).catch((err) => {
            console.error(err);
        });
    }

    public async callUser(calleeEmail: string, callerEmail: string, callerFullName: string, callerImgPath: string) {
        await this.hubConnection.invoke('CallUser', calleeEmail, callerEmail, callerFullName, callerImgPath).catch((err) => {
            console.error(err);
        });
    }

    public async acceptCall(callerEmail: string, calleeEmail: string, calleeFullName: string, roomName: string) {
        await this.hubConnection.invoke('AcceptCall', callerEmail, calleeEmail, calleeFullName, roomName).catch((err) => {
            console.error(err);
        });
    }

    public async rejectCall(email: string) {
        await this.hubConnection.invoke('RejectCall', email).catch((err) => {
            console.error(err);
        });
    }

    public async endCall(roomName: string) {
        await this.hubConnection.invoke('EndCall', roomName).catch((err) => {
            console.error(err);
        });
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
