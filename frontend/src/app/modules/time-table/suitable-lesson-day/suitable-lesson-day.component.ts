import { Component, Input } from '@angular/core';
import * as moment from 'moment';

@Component({
    selector: 'app-suitable-lesson-day',
    templateUrl: './suitable-lesson-day.component.html',
    styleUrls: ['./suitable-lesson-day.component.sass'],
})
export class SuitableLessonDayComponent {
    @Input() days: Date[] = [new Date()];

    @Input() item: Date = new Date();

    @Input() meetingCount: number = 0;

    todayDate: Date = new Date();

    isToday(): boolean {
        return moment(this.item).isSame(this.todayDate, 'days');
    }

    compareDate(): boolean {
        return moment(this.item).isBefore(moment(), 'day');
    }
}
