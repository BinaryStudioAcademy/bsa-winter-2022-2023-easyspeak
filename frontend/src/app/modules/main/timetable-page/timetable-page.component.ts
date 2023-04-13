import { Component } from '@angular/core';
import { LanguageLevel } from '@shared/data/languageLevel';
import { IIcon } from '@shared/models/IIcon';

@Component({
    selector: 'app-timetable-page',
    templateUrl: './timetable-page.component.html',
    styleUrls: ['./timetable-page.component.sass'],
})
export class TimetablePageComponent {
    selectedLanguageFilters: LanguageLevel[] = [];

    selectedInterestsFilters: IIcon[] = [];

    selectedDateFilter: Date;

    onSelectedLanguageFiltersChange(selectedLanguageFilters: LanguageLevel[]) {
        this.selectedLanguageFilters = [...selectedLanguageFilters];
    }

    onSelectedInterestsFiltersChange(selectedInterestsFilters: IIcon[]) {
        this.selectedInterestsFilters = [...selectedInterestsFilters];
    }

    onDateSelected(dateSelected: Date) {
        this.selectedDateFilter = dateSelected;
    }
}
