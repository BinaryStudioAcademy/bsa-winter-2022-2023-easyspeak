import { Injectable } from '@angular/core';
import { SignalRHubFactoryService } from '@core/hubs/hubFactories/signalr-hub-factory.service';
import { environment } from '@env/environment';

@Injectable({
    providedIn: 'root',
})
export class NotifierHubFactoryService extends SignalRHubFactoryService {
    buildUrl(hubUrl: string): string {
        return `${environment.notifierUrl}/${hubUrl}`;
    }
}
