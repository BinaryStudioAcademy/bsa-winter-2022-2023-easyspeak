import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { IUserNotification } from '@shared/models/IUserNotification';
import { Subject, Subscription } from 'rxjs';

import { SignalRHubFactoryService } from './signalr-hub-factory.service';

@Injectable({
    providedIn: 'root',
})
export class NotificationsHubService {
    readonly hubUrl = 'notificationsHub';

    private hubConnection: HubConnection;

    readonly messages = new Subject<IUserNotification>();

    private subscriptions: Subscription[] = [];

    // eslint-disable-next-line no-empty-function
    constructor(private hubFactory: SignalRHubFactoryService) {}

    async start() {
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    listenMessages(action: (msg: IUserNotification) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
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

        this.hubConnection.on('BroadcastMessage', (msg: IUserNotification) => {
            this.messages.next(msg);
        });
    }
}
