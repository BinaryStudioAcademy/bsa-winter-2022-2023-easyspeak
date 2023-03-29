import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IIDayCard } from '@shared/models/lesson/IDayCard';
import * as moment from 'moment';

import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-suitable-lesson',
    templateUrl: './suitable-lesson.component.html',
    styleUrls: ['./suitable-lesson.component.sass'],
})
export class SuitableLessonComponent implements OnInit {
    @Output() dateSelected = new EventEmitter<Date>();

    readonly amountOfDayInWeek: number = 7;

    days: IIDayCard[] = [];

    selectedDate: Date = new Date();

    constructor(private lessonService: LessonsService) { }

    ngOnInit(): void {
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
        this.selectedDate.setDate(this.selectedDate.getDate() + this.amountOfDayInWeek);

        this.setDays();

        this.dateSelected.emit(new Date(this.selectedDate));
    }

    weekDec(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() - this.amountOfDayInWeek);

        this.setDays();

        if (moment(this.selectedDate).isSameOrAfter(moment(), 'day')) {
            this.dateSelected.emit(new Date(this.selectedDate));
        }
    }

    setDays(): void {
        this.days = Array(this.amountOfDayInWeek).fill({}).map((_, i) => {
            const date = moment(this.selectedDate).add(i - this.selectedDate.getDay() + 1, 'day').toDate();

            return { date, meetingsAmount: 0 };
        });

        const requestDate = this.selectedDate.toISOString().slice(0, 10);

        this.lessonService.getLessonsCount(requestDate).subscribe(response => {
            this.days = this.days.map(day => {
                const matchingDate = response.find(el => new Date(el.date).getDay() === day.date.getDay());

                return matchingDate ? { date: day.date, meetingsAmount: matchingDate.meetingsAmount } : day;
            });
        });
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDate = dateSelected;
        this.dateSelected.emit(dateSelected);
    }
}
