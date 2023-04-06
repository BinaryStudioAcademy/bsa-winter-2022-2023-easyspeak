import { Injectable } from '@angular/core';
import { CoreHubFactoryService } from '@core/hubs/hubFactories/core-hub-factory.service';
import { HubConnection, HubConnectionState } from '@microsoft/signalr';
import { IMessage } from '@shared/models/chat/IMessage';
import { Observable, Subject, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ChatHubService {
    readonly hubUrl = 'chatting';

    private hubConnection: HubConnection;

    readonly messages = new Subject<IMessage>();

    constructor(private hubFactory: CoreHubFactoryService) {}

    async start() {
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    private async init() {
        await this.hubConnection
            .start()
            .then(() => console.info(`"${this.hubFactory}" successfully started.`))
            .catch(() => console.info(`"${this.hubFactory}" failed.`));
    }

    public get AllMessagesObservable(): Observable<IMessage> {
        return this.messages.asObservable();
    }

    public listenToSendMessages() {
        (<HubConnection> this.hubConnection).on('GetMessageAsync', (data: IMessage) => {
            this.messages.next(data);
        });
    }

    async invoke(methodName: string, ...args: unknown[]): Promise<unknown> {
        return this.hubConnection.invoke(methodName, ...args);
    }

    isConnected(): boolean {
        return this.hubConnection && this.hubConnection.state === HubConnectionState.Connected;
    }
}
