import { Injectable } from '@angular/core';
import { NotifierHubFactoryService } from '@core/hubs/hubFactories/notifier-hub-factory.service';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { IChatPerson } from '@shared/models/chat/IChatPerson';
import { IMessage } from '@shared/models/chat/IMessage';
import { Subject, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ChatHubService {
    readonly hubUrl = 'chatting';

    private hubConnection: HubConnection;

    readonly messages = new Subject<IMessage>();

    readonly people = new Subject<IChatPerson[]>();

    private subscriptions: Subscription[] = [];

    constructor(private hubFactory: NotifierHubFactoryService) {}

    async start() {
        if (!this.hubConnection || this.hubConnection.state === HubConnectionState.Disconnected) {
            this.hubConnection = this.hubFactory.createHub(this.hubUrl);
            await this.init();
        }
    }

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('message', (msg: IMessage) => {
            this.messages.next(msg);
        });

        this.hubConnection.on('chats', (people: IChatPerson[]) => {
            this.people.next(people);
        });
    }

    public async end() {
        await this.people.unsubscribe();
        await this.messages.unsubscribe();
    }

    public listenChats(action: (people: IChatPerson[]) => void) {
        this.subscriptions.push(this.people.subscribe({ next: action }));
    }

    public listenMessages(action: (msg: IMessage) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
