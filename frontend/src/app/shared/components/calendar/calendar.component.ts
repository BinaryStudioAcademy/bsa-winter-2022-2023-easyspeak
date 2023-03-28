import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.sass'],
})
export class CalendarComponent {
    maxDate = new Date();

    minDate = new Date(1900, 0, 1);

    @Input() placeholder: string;
}
