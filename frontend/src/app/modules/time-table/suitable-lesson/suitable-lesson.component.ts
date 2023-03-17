import { Component } from '@angular/core';
import * as moment from 'moment';

@Component({
    selector: 'app-suitable-lesson',
    templateUrl: './suitable-lesson.component.html',
    styleUrls: ['./suitable-lesson.component.sass'],
})
export class SuitableLessonComponent {
    days: Date[] = [];

    selectedDate: Date = new Date();

    constructor() {
        this.setDays();
    }

    select(event: Date | null) {
        if (event) {
            this.selectedDate = event;
            this.selectedDate.setDate(this.selectedDate.getDate() - 1);
            this.setDays();
        }
    }

    weekInc(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() + 7);

        this.setDays();
    }

    weekDec(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() - 7);

        this.setDays();
    }

    setDays(): void {
        for (let i = 0; i < 7; i++) {
            this.days[i] = moment(this.selectedDate)
                .add(i - this.selectedDate.getDay() + 1, 'day')
                .toDate();
        }
    }
}
