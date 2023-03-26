import { Component, EventEmitter, Input, Output } from '@angular/core';
import * as moment from 'moment';

@Component({
    selector: 'app-suitable-lesson-day',
    templateUrl: './suitable-lesson-day.component.html',
    styleUrls: ['./suitable-lesson-day.component.sass'],
})
export class SuitableLessonDayComponent {
    @Output() dateSelected = new EventEmitter<Date>();

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

    onDayClick(event: MouseEvent) {
        const target = event.target as HTMLElement;

        if (target.classList.contains('day-elem')) {
            const prevSelected = document.querySelector('.day-elem-blue');

            if (prevSelected) {
                const prevSelectedIsToday = prevSelected.classList.contains('day-elem-blue-today');

                if (!target.classList.contains('day-elem-grey')) {
                    prevSelected.classList.remove('day-elem-blue');
                    prevSelected.classList.remove('day-elem-blue-today');
                    if (prevSelectedIsToday) {
                        prevSelected.classList.add('day-elem-white-today');
                    } else {
                        prevSelected.classList.add('day-elem-white');
                    }
                }
            }

            if (target.classList.contains('day-elem-grey')) {
                return;
            } if (target.classList.contains('day-elem-blue-today')) {
                target.classList.remove('day-elem-blue');
                target.classList.remove('day-elem-blue-today');
                target.classList.add('day-elem-white-today');
            } else {
                target.classList.remove('day-elem-white');
                target.classList.add('day-elem-blue');
                if (target.classList.contains('day-elem-blue')) {
                    const isToday = moment(this.item).isSame(this.todayDate, 'days');

                    if (isToday) {
                        target.classList.add('day-elem-blue-today');
                    }
                }
            }
        }

        if (!target.classList.contains('day-elem-grey')) {
            this.dateSelected.emit(this.item);
        }
    }
}
