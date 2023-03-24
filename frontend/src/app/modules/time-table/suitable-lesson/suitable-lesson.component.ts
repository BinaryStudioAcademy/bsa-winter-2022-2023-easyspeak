import { Component, EventEmitter, Output } from '@angular/core';
import { ILesson } from '@shared/models/lesson/ILesson';
import * as moment from 'moment';
import { catchError, forkJoin, map, Observable, of, tap } from 'rxjs';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-suitable-lesson',
    templateUrl: './suitable-lesson.component.html',
    styleUrls: ['./suitable-lesson.component.sass'],
})
export class SuitableLessonComponent {
    @Output() dateSelected = new EventEmitter<Date>();

    readonly amountOfDayInWeek: number = 7;

    days: { date: Date, meetingsCount: number }[];

    selectedDate: Date = new Date();

    meetingsCount: number

    constructor(private lessonService: LessonsService) {
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
        for (let i = 0; i < 7; i++) {
            const date = moment(this.selectedDate).add(i - this.selectedDate.getDay() + 1, 'day').toDate();
            const meetingsCount = await this.getMeetingCount(date);
            this.days.push({ date, meetingsCount });
        }
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
        this.dateSelected.emit(dateSelected);
      }
}
