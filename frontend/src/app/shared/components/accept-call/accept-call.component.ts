import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';
import { IModal } from '@shared/models/IModal';

@Component({
    selector: 'app-accept-call',
    templateUrl: './accept-call.component.html',
    styleUrls: ['./accept-call.component.sass'],
})
export class AcceptCallComponent {
    constructor(
        @Inject(MAT_DIALOG_DATA) public data: IModal,
        private router: Router,
        private webRtcHub: WebrtcHubService,
    ) {}

    accept() {
        this.router.navigate([`session-call/${this.data.header}`]);
    }
}
