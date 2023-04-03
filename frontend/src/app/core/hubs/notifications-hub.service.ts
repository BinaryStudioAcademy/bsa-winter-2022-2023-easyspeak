import { Injectable } from '@angular/core';
import { NotifierHubFactoryService } from '@core/hubs/hubFactories/notifier-hub-factory.service';
import { HubConnection } from '@microsoft/signalr';
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
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    listenMessages(action: (msg: string) => void) {
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

        const storedUserData = localStorage.getItem('user');
        let userEmail: string = 'Test@test.ua';

        if (storedUserData) {
            userEmail = JSON.parse(storedUserData).email.toLowerCase();
        }

        this.hubConnection.on(`Notification_${userEmail}`, (msg: string) => {
            this.messages.next(msg);
        });
    }
}
