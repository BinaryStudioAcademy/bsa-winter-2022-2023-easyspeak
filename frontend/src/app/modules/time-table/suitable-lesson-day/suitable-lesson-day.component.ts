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
        const itemMoment = moment(this.item);
        const todayMoment = moment(this.todayDate);

        if (itemMoment.diff(todayMoment, 'days', true) > -1 && itemMoment.diff(todayMoment, 'days', true) < 0) {
            return true;
        }

        return false;
    }

    compareDate(): boolean {
        const valueMoment = moment(this.item);

        const todayMoment = moment();

        return valueMoment.isBefore(todayMoment, 'day');
    }
}
