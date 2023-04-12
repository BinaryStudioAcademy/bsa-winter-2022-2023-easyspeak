import { Component } from '@angular/core';
import { IIcon } from '@shared/models/IIcon';

@Component({
    selector: 'app-timetable-page',
    templateUrl: './timetable-page.component.html',
    styleUrls: ['./timetable-page.component.sass'],
})
export class TimetablePageComponent {
    selectedLanguageFilters: string[] = [];

    selectedInterestsFilters: IIcon[] = [];

    selectedDateFilter: Date;

    onSelectedLanguageFiltersChange(selectedLanguageFilters: string[]) {
        this.selectedLanguageFilters = [...selectedLanguageFilters];
    }

    onSelectedInterestsFiltersChange(selectedInterestsFilters: IIcon[]) {
        this.selectedInterestsFilters = [...selectedInterestsFilters];
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDateFilter = dateSelected;
    }
}
