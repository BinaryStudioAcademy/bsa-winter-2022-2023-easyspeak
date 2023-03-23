import { Component } from '@angular/core';

@Component({
    selector: 'app-timetable-page',
    templateUrl: './timetable-page.component.html',
    styleUrls: ['./timetable-page.component.sass'],
})
export class TimetablePageComponent {
    selectedTopicsFilters = new Set<string>();
    selectedLanguageFilters = new Set<string>();
    selectedDateFilter: Date;

    onSelectedTopicsFiltersChange(selectedTopicsFilters: Set<string>) {
        this.selectedTopicsFilters = selectedTopicsFilters;
    }

    onSelectedLanguageFiltersChange(selectedLanguageFilters: Set<string>) {
        this.selectedLanguageFilters = selectedLanguageFilters;
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDateFilter = dateSelected;
      }
}
