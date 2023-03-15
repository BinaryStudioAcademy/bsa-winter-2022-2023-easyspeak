import { Component } from '@angular/core';

@Component({
    selector: 'app-suitable-lesson',
    templateUrl: './suitable-lesson.component.html',
    styleUrls: ['./suitable-lesson.component.sass'],
})
export class SuitableLessonComponent {
    update: any = true;

    weekdays: string[] = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];

    month: string[] = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
        'July   ',
        'August',
        'September',
        'October',
        'November',
        'December',
    ];

    days: Date[] = [new Date(), new Date(), new Date(), new Date(), new Date(), new Date(), new Date()];

    todayDate: Date = new Date();

    dayOfWeek: any;

    startDate: Date = new Date();

    currentDate: Date = new Date();

    selectedDate: Date = new Date();

    isSelected: any;

    constructor() {
        this.dayOfWeek = this.weekdays[new Date(this.currentDate.getMilliseconds()).getUTCDay()];
        this.setDays();
    }

    weekInc(): void {
        this.currentDate = this.startDate;

        this.startDate = new Date(this.currentDate.setDate(this.currentDate.getDate() + 7));

        this.setDays();
    }

    weekDec(): void {
        this.currentDate = this.startDate;

        this.startDate = new Date(this.currentDate.setDate(this.currentDate.getDate() - 7));

        this.setDays();
    }

    getWeekDayString(inDate: Date): string {
        return this.weekdays[new Date(inDate).getUTCDay()];
    }

    getWeekDayNumber(inDate: Date): number {
        return new Date(inDate).getUTCDay();
    }

    getMonthString(inDate: Date): string {
        return this.month[inDate.getMonth()];
    }

    getDayNumber(inNumber: number): string {
        if (inNumber > 9) {
            return inNumber.toString();
        }

        // eslint-disable-next-line prefer-template
        return '0' + inNumber.toString();
    }

    setDays(): void {
        const tempDate: Date = this.startDate;

        const tempDayOfWeek: number = this.startDate.getDay();

        for (let i = 0; i < 7; i++) {
            const day: Date = new Date(
                tempDate.getFullYear(),
                tempDate.getMonth(),
                tempDate.getDate() + i - tempDayOfWeek + 1,
            );

            this.days[i] = day;
        }
    }

    select(event: any, calendar: any) {
        this.startDate = event;
        this.setDays();
        calendar.updateTodaysDate();
    }

    compareDate(dateToCheck: Date, dateNow: Date): boolean {
        const value: Date = new Date(dateToCheck.getFullYear(), dateToCheck.getMonth(), dateToCheck.getDate() + 1);

        return value < dateNow;
    }
}
