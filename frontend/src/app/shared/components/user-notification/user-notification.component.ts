import { Component, OnInit } from '@angular/core';
import { SignalrService } from '@core/services/signalr.service';

@Component({
    selector: 'app-user-notification',
    templateUrl: './user-notification.component.html',
    styleUrls: ['./user-notification.component.sass'],
})
export class UserNotificationComponent implements OnInit {
    readonly signalrService: SignalrService;

    constructor(signalrService: SignalrService) {
        this.signalrService = signalrService;
    }

    ngOnInit(): void {
        this.signalrService.startConnection();
        this.signalrService.addTransferChartDataListener();
    }
}
