import { Component } from '@angular/core';
import { HttpService } from '@core/services/http.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.sass'],
})
export class HeaderComponent {
    constructor(private ser: HttpService) {
        this.ser.get("/someUrl").subscribe();
    }
}
