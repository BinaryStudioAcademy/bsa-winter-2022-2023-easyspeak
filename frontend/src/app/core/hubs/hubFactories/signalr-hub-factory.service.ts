import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

export abstract class SignalRHubFactoryService {
    private hubLookup = new Map<string, HubConnection>();

    createHub(hubUrl: string) {
        if (this.hubLookup.has(hubUrl)) {
            return this.hubLookup.get(hubUrl)!;
        }

        const hub = this.buildHub(hubUrl);

        this.hubLookup.set(hubUrl, hub);

        return hub;
    }

    private buildHub(hubUrl: string) {
        return new HubConnectionBuilder()
            .withUrl(this.buildUrl(hubUrl), {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
            })
            .configureLogging(LogLevel.Information)
            .build();
    }

    abstract buildUrl(hubUrl: string): string;
}
