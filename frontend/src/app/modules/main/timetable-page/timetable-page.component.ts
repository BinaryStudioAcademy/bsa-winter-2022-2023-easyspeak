import { Component } from '@angular/core';

@Component({
    selector: 'app-timetable-page',
    templateUrl: './timetable-page.component.html',
    styleUrls: ['./timetable-page.component.sass'],
})
export class TimetablePageComponent {
    selectedLanguageFilters: string[] = [];

    selectedInterestsFilters: string[] = [];

    selectedDateFilter: Date;

    onSelectedLanguageFiltersChange(selectedLanguageFilters: string[]) {
        this.selectedLanguageFilters = [...selectedLanguageFilters];
    }

    onSelectedInterestsFiltersChange(selectedInterestsFilters: string[]) {
        this.selectedInterestsFilters = [...selectedInterestsFilters];
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDateFilter = dateSelected;
    }
}
