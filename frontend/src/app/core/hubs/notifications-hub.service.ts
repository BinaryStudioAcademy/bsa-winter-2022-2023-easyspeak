import { Injectable } from '@angular/core';
import { NotifierHubFactoryService } from '@core/hubs/hubFactories/notifier-hub-factory.service';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { Subject, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class NotificationsHubService {
    readonly hubUrl = 'notificationsHub';

    private hubConnection: HubConnection;

    public readonly messages = new Subject<string>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: NotifierHubFactoryService) {}

    async start() {
        if (!this.hubConnection || this.hubConnection.state === HubConnectionState.Disconnected) {
            this.hubConnection = this.hubFactory.createHub(this.hubUrl);
            await this.init();
        }
    }

    listenMessages(action: (msg: string) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    async stop() {
        this.subscriptions.forEach((s) => s.unsubscribe());
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

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('Notify', (msg: string) => {
            this.messages.next(msg);
        });
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
