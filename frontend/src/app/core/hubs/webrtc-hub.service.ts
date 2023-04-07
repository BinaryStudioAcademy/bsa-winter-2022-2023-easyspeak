import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { CoreHubFactoryService } from '@core/hubs/hubFactories/core-hub-factory.service';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { AcceptCallComponent } from '@shared/components/accept-call/accept-call.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { IModal } from '@shared/models/IModal';
import { Subject, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class WebrtcHubService {
    readonly hubUrl = 'signaling';

    private hubConnection: HubConnection;

    readonly messages = new Subject<string>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: CoreHubFactoryService, private dialogRef: MatDialog) {}

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

        this.hubConnection.on('UserConnected', (username: string) => {
            console.log(`${username} has connected`);
        });

        this.hubConnection.on('UserDisconnected', (username: string) => {
            console.log(`${username} has disconnected`);
        });

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

        this.hubConnection.on('call', (roomName: string) => {
            const config: MatDialogConfig<IModal> = {
                data: {
                    header: roomName,
                },
            };

            this.dialogRef.open(AcceptCallComponent, config);
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

    public async callUser(email: string, roomName: string) {
        await this.hubConnection.invoke('CallUser', email, roomName).catch((err) => console.log(err));
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
