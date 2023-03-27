import { Component } from '@angular/core';

@Component({
    selector: 'app-timetable-page',
    templateUrl: './timetable-page.component.html',
    styleUrls: ['./timetable-page.component.sass'],
})
export class TimetablePageComponent {
    selectedLanguageFilters = new Set<string>();

    selectedInterestsFilters = new Set<string>();

    selectedDateFilter: Date;

    onSelectedLanguageFiltersChange(selectedLanguageFilters: Set<string>) {
        this.selectedLanguageFilters = new Set<string>([...selectedLanguageFilters]);
    }

    onSelectedInterestsFiltersChange(selectedInterestsFilters: Set<string>) {
        this.selectedInterestsFilters = new Set<string>([...selectedInterestsFilters]);
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDateFilter = dateSelected;
    }
}
