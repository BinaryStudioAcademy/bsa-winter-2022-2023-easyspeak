import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { langLevelsSample, topicsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { Subject } from 'rxjs';

import { Filter } from 'src/app/models/filters/filter';

@Component({
    selector: 'app-filter-section',
    templateUrl: './filter-section.component.html',
    styleUrls: ['./filter-section.component.sass'],
})
export class FilterSectionComponent implements OnInit {
    @Output() selectedLanguageFiltersChange = new EventEmitter<Set<string>>();

    @Output() selectedInterestsFiltersChange = new EventEmitter<Set<string>>();

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public langBtnLabel = 'Level';

    public selectedLanguageFilters = new Set<string>();

    public selectedInterestsFilters = new Set<string>();


    public langLevels: Filter[];

    ngOnInit(): void {
        this.langLevels = langLevelsSample;
    }

    removeLangLevel(title: string) {
        this.selectedLanguageFilters.delete(title);
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    removeInterest(title: string) {
        this.selectedInterestsFilters.delete(title);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    updateLangFilters(eventData: Set<string>) {
        this.selectedLanguageFilters = eventData;
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    updateInterestFilters(eventData: Set<string>) {
        this.selectedInterestsFilters = eventData;
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();

        this.selectedLanguageFilters.clear();
        this.selectedInterestsFilters.clear();

        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }
}
