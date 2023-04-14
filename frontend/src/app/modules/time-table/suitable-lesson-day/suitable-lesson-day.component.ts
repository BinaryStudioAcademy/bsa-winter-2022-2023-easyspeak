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

    isToday = () => moment(this.item).isSame(this.todayDate, 'days');

    isBeforeToday = () => moment(this.item).isBefore(moment(), 'day');

    isSelectedDay = () => moment(this.item).isSame(this.selectedDate, 'days');

    onDayClick(eventData: Event) {
        const target = eventData.target as HTMLElement;
        const targetClasses = target.classList;
        const classesToCheck = ['day-elem-grey', 'disabled', 'meetings-grey'];

        if (!classesToCheck.some(className => targetClasses.contains(className))) {
            this.dateSelected.emit(this.item);
        }
    }

    meetingNumber = () => (this.meetingCount === 1 ? 'group class' : 'group classes');
}
