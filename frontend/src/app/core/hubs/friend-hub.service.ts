import { Injectable } from '@angular/core';
import { CoreHubFactoryService } from '@core/hubs/hubFactories/core-hub-factory.service';
import { HubConnection } from '@microsoft/signalr';
import { Subject, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class FriendHubService {
    readonly hubUrl = 'friend';

    private hubConnection: HubConnection;

    readonly acceptEmails = new Subject<string>();

    readonly followEmails = new Subject<string>();

    readonly rejectEmails = new Subject<string>();

    private subscriptions: Subscription[] = [];

    // eslint-disable-next-line no-empty-function
    constructor(private hubFactory: CoreHubFactoryService) {}

    async start() {
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    listenFollow(action: (msg: string) => void) {
        this.subscriptions.push(this.followEmails.subscribe({ next: action }));
    }

    listenAccept(action: (msg: string) => void) {
        this.subscriptions.push(this.acceptEmails.subscribe({ next: action }));
    }

    listenReject(action: (msg: string) => void) {
        this.subscriptions.push(this.rejectEmails.subscribe({ next: action }));
    }

    async stop() {
        await this.hubConnection?.stop();
        this.subscriptions.forEach((s) => s.unsubscribe());
    }

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('Follow', (msg: string) => {
            this.followEmails.next(msg);
        });
        this.hubConnection.on('Accept', (msg: string) => {
            this.acceptEmails.next(msg);
        });
        this.hubConnection.on('Reject', (msg: string) => {
            this.rejectEmails.next(msg);
        });
    }
}
