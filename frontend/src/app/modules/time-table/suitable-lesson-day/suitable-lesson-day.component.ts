import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';

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

    getWeekDayString(): string {
        return new DatePipe('en-US').transform(this.item, 'EEEE') ?? '';
    }

    getMonthString(inDate: Date): string {
        return new DatePipe('en-US').transform(inDate, 'MMMM') ?? ' ';
    }

    isToday(): boolean {
        if (
            this.item.getDate() === this.todayDate.getDate() &&
            this.item.getMonth() === this.todayDate.getMonth() &&
            this.item.getFullYear() === this.todayDate.getFullYear()
        ) {
            return true;
        }

        return false;
    }

    compareDate(): boolean {
        const value: Date = new Date(this.item.getFullYear(), this.item.getMonth(), this.item.getDate() + 1);

        return value < this.todayDate;
    }

    formatDayMonthString(): string {
        const dateFormat = 'dd MMMM';
        const formattedDate1 = new DatePipe('en-US').transform(this.item, dateFormat);

        return `${formattedDate1}`;
    }
}
