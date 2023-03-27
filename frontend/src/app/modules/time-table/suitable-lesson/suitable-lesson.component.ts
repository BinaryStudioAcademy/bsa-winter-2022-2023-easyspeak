import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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

    days: { date: Date, meetingsCount: number }[];

    selectedDate: Date = new Date();

    meetingsCount: number;

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
    }

    weekDec(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() - this.amountOfDayInWeek);

        this.setDays();
    }

    async setDays(): Promise<void> {
        this.days = [];
        const promises: Promise<{ date: Date, meetingsCount: number }>[] = [];

        for (let i = 0; i < 7; i++) {
            const date = moment(this.selectedDate).add(i - this.selectedDate.getDay() + 1, 'day').toDate();
            const promise = this.getMeetingCount(date).then(meetingsCount => ({ date, meetingsCount }));

            promises.push(promise);
        }

        const days = await Promise.all(promises);

        this.days = days.sort((a, b) => a.date.getTime() - b.date.getTime());
    }

    async getMeetingCount(date: Date): Promise<number> {
        const filteredLessons = await this.lessonService.getFilteredLessons({
            languageLevels: [],
            tags: [],
            date: new Date(date.toISOString().slice(0, 10)),
        }).toPromise();

        return filteredLessons?.length || 0;
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDate = dateSelected;
        this.dateSelected.emit(dateSelected);
    }
}
