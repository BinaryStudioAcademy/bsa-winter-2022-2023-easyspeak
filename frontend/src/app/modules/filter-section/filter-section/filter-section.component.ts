import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { IIcon } from '@shared/models/IIcon';
import { Subject } from 'rxjs';

import { Filter } from 'src/app/models/filters/filter';

@Component({
    selector: 'app-filter-section',
    templateUrl: './filter-section.component.html',
    styleUrls: ['./filter-section.component.sass'],
})
export class FilterSectionComponent implements OnInit {
    @Output() selectedLanguageFiltersChange = new EventEmitter<string[]>();

    @Output() selectedInterestsFiltersChange = new EventEmitter<IIcon[]>();

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public langBtnLabel = 'Level';

    @Input() selectedLanguageFilters: string[] = [];

    public selectedLevelWithSubtitleFilters: string[] = [];

    public selectedInterestsFilters: IIcon[] = [];

    public langLevels: Filter[];

    ngOnInit(): void {
        this.langLevels = langLevelsSample;
    }

    removeLangLevel(title: string) {
        const splitedTitle = title.split(':');

        this.selectedLanguageFilters = this.selectedLanguageFilters.filter(filterTitle => filterTitle !== splitedTitle[0]);
        this.selectedLevelWithSubtitleFilters = this.getLanguageLevelWithSubtitle();
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    removeInterest(topic: IIcon) {
        this.selectedInterestsFilters = this.selectedInterestsFilters.filter(filter => filter !== topic);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    updateLangFilters(eventData: string[]) {
        this.selectedLanguageFilters = eventData;
        this.selectedLevelWithSubtitleFilters = this.getLanguageLevelWithSubtitle();
        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
    }

    updateInterestFilters(eventData: IIcon[]) {
        this.selectedInterestsFilters = eventData;
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();

        this.selectedLanguageFilters = [];
        this.selectedInterestsFilters = [];
        this.selectedLevelWithSubtitleFilters = [];

        this.selectedLanguageFiltersChange.emit(this.selectedLanguageFilters);
        this.selectedInterestsFiltersChange.emit(this.selectedInterestsFilters);
    }

    isVisibilityButton = () => this.selectedInterestsFilters.length || this.selectedLanguageFilters.length;

    private getLanguageLevelWithSubtitle() {
        return this.selectedLanguageFilters.map(f => {
            const level = this.langLevels.find(l => l.title === f);

            return `${level?.title}: ${level?.subtitle}`;
        });
    }
}
