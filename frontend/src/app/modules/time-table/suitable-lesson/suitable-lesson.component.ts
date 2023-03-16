import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';

@Component({
    selector: 'app-suitable-lesson',
    templateUrl: './suitable-lesson.component.html',
    styleUrls: ['./suitable-lesson.component.sass'],
})
export class SuitableLessonComponent {
    days: Date[] = [];

    selectedDate: Date = new Date();

    isSelected: any;

    constructor() {
        this.setDays();
    }

    // eslint-disable-next-line @typescript-eslint/no-unused-vars, no-unused-vars
    select(event: any, calendar: any) {
        this.selectedDate = event;
        this.selectedDate.setDate(this.selectedDate.getDate() - 1);
        this.setDays();
    }

    weekInc(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() + 7);

        this.setDays();
    }

    weekDec(): void {
        this.selectedDate.setDate(this.selectedDate.getDate() - 7);

        this.setDays();
    }

    getWeekDayString(inDate: Date): string {
        return new DatePipe('en-US').transform(inDate, 'EEEE') ?? '';
    }

    getMonthString(inDate: Date): string {
        return new DatePipe('en-US').transform(inDate, 'MMMM') ?? ' ';
    }

    getDayNumber(inNumber: number): string {
        if (inNumber > 9) {
            return inNumber.toString();
        }

        // eslint-disable-next-line prefer-template
        return '0' + inNumber.toString();
    }

    getCalendarMonthString(): string {
        const dateFormat = 'dd MMMM';
        const formattedDate1 = new DatePipe('en-US').transform(this.days[0], dateFormat);
        const formattedDate2 = new DatePipe('en-US').transform(this.days[6], dateFormat);

        return `${formattedDate1} - ${formattedDate2}`;
    }

    setDays(): void {
        const tempDate: Date = this.selectedDate;

        const tempDayOfWeek: number = this.selectedDate.getDay();

        for (let i = 0; i < 7; i++) {
            const day: Date = new Date(
                tempDate.getFullYear(),
                tempDate.getMonth(),
                tempDate.getDate() + i - tempDayOfWeek + 1,
            );

            this.days[i] = day;
        }
    }
}
