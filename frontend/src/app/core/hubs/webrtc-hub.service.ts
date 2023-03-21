import { Injectable } from '@angular/core';
import {HubConnection, HubConnectionState} from '@microsoft/signalr';
import { Subject, Subscription } from 'rxjs';

import { SignalRHubFactoryService } from './signalr-hub-factory.service';

@Injectable({
    providedIn: 'root',
})
export class WebrtcHubService {
    readonly hubUrl = 'signaling';

    private hubConnection: HubConnection;

    readonly messages = new Subject<string>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: SignalRHubFactoryService) {}

    async start() {
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    listenMessages(action: (msg: any) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    async stop() {
        await this.hubConnection?.stop();
        this.subscriptions.forEach((s) => s.unsubscribe());
    }

    disconnect(): void {
        if (this.isConnected()) {
            this.hubConnection.stop();
        }
    }

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('log', (msg: string) => {
            this.messages.next(msg);
        });

        this.hubConnection.on('created', (msg: string) => {
            this.messages.next('created');
        });

        this.hubConnection.on('joined', (msg: string) => {
            this.messages.next('joined');
        });

        this.hubConnection.on('message', (msg: string) => {
            this.messages.next(msg);
        });
    }

    async invoke(methodName: string, ...args: any[]): Promise<any> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
