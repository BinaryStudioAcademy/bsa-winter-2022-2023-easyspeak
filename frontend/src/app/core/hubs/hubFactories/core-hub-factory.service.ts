import { Injectable } from '@angular/core';
import { SignalRHubFactoryService } from '@core/hubs/hubFactories/signalr-hub-factory.service';
import { environment } from '@env/environment';

@Injectable({
    providedIn: 'root',
})
export class CoreHubFactoryService extends SignalRHubFactoryService {
    buildUrl(hubUrl: string): string {
        return `${environment.coreUrl}/${hubUrl}`;
    }
}
