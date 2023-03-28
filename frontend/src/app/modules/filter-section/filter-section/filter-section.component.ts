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
    @Output() selectedTopicsFiltersChange = new EventEmitter<Set<string>>();

    @Output() selectedLanguageFiltersChange = new EventEmitter<Set<string>>();

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public langBtnLabel = 'Level';

    public topicsBtnLabel = 'Interests';

    public selectedLanguageFilters = new Set<string>();

    public selectedTopicsFilters = new Set<string>();

    public topics: Filter[];

    public langLevels: Filter[];

    ngOnInit(): void {
        this.topics = topicsSample;
        this.langLevels = langLevelsSample;
    }

    removeLangLevel(title: string) {
        this.selectedLanguageFilters.delete(title);
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    removeTopic(title: string) {
        this.selectedTopicsFilters.delete(title);
        this.selectedTopicsFiltersChange.emit(this.selectedTopicsFilters);
    }

    updateLangFilters(eventData: Set<string>) {
        this.selectedLanguageFilters = eventData;
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    updateTopicFilters(eventData: Set<string>) {
        this.selectedTopicsFilters = eventData;
        this.selectedTopicsFiltersChange.emit(this.selectedTopicsFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();
        this.selectedLanguageFilters = new Set();
        this.selectedTopicsFilters = new Set();
        this.selectedTopicsFiltersChange.emit(this.selectedTopicsFilters);
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    isVisibilityButton = () => this.selectedTopicsFilters.size || this.selectedLanguageFilters.size;
}
