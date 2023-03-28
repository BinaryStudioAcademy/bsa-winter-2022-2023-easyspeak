import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { Subject } from 'rxjs';

import { Filter } from 'src/app/models/filters/filter';

@Component({
    selector: 'app-filter-section',
    templateUrl: './filter-section.component.html',
    styleUrls: ['./filter-section.component.sass'],
})
export class FilterSectionComponent implements OnInit {
    @Output() selectedLanguageFiltersChange = new EventEmitter<string[]>();

    @Output() selectedInterestsFiltersChange = new EventEmitter<string[]>();

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public langBtnLabel = 'Level';

    @Input() selectedLanguageFilters: string[] = [];

    public selectedInterestsFilters: string[] = [];

    public langLevels: Filter[];

    ngOnInit(): void {
        this.langLevels = langLevelsSample;
    }

    removeLangLevel(title: string) {
        this.selectedLanguageFilters = this.selectedLanguageFilters.filter(filterTitle => filterTitle !== title);
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    removeInterest(title: string) {
        this.selectedInterestsFilters = this.selectedInterestsFilters.filter(filterTitle => filterTitle !== title);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    updateLangFilters(eventData: string[]) {
        this.selectedLanguageFilters = eventData;
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    updateInterestFilters(eventData: string[]) {
        this.selectedInterestsFilters = eventData;
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();

        this.selectedLanguageFilters = [];
        this.selectedInterestsFilters = [];

        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }
}
