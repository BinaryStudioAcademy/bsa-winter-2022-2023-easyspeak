import { Component, EventEmitter, Input, Output } from '@angular/core';
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

    @Input() selectedDate: Date;

    @Output() dateSelected = new EventEmitter<Date>();

    todayDate: Date = new Date();

    isToday(): boolean {
        const isSameToday = moment(this.item).isSame(this.todayDate, 'days');

        return isSameToday;
    }

    isBeforeToday(): boolean {
        const isBeforeToday = moment(this.item).isBefore(moment(), 'day');

        return isBeforeToday;
    }

    isSelectedDay(): boolean {
        const isSameSeleted = moment(this.item).isSame(this.selectedDate, 'days');

        return isSameSeleted;
    }

    onDayClick(eventData: Event) {
        const target = eventData.target as HTMLElement;

        if (!target.classList.contains('day-elem-grey')) {
            this.dateSelected.emit(this.item);
        }
    }
}
