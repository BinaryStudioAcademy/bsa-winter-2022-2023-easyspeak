import { Component, OnInit } from '@angular/core';
import { langLevelsSample, topicsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { Subject } from 'rxjs';

import { Filter } from '../../../models/filters/filter';
import { CountriesTzLangProviderService } from '../../../services/countries-tz-lang-provider.service';

@Component({
    selector: 'app-filter-section',
    templateUrl: './filter-section.component.html',
    styleUrls: ['./filter-section.component.sass'],
})
export class FilterSectionComponent implements OnInit {
    public constructor(private languageTimezone: CountriesTzLangProviderService) {
    }

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public levelBtnLabel = 'Level';

    public topicsBtnLabel = 'Interests';

    public langBtnLabel = 'Native Language';

    public compatibilityBtnLabel = 'Compatibility';

    public selectedLevelFilters = new Set<string>();

    public selectedTopicsFilters = new Set<string>();

    public selectedLanguagesFilters = new Set<string>();

    public selectedCompatibilityFilters = new Set<string>();

    public topics: Filter[];

    public langLevels: Filter[];

    public languages: Filter[];

    public compatibility: Filter[];

    ngOnInit(): void {
        this.topics = topicsSample;
        this.langLevels = langLevelsSample;
        this.languages = this.languageTimezone.getLanguagesList().map(s => ({ title: s }));
    }

    remove(param: 'lang' | 'level' | 'topic', title: string) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters.delete(title);
                break;
            case 'level':
                this.selectedLevelFilters.delete(title);
                break;
            case 'topic':
                this.selectedTopicsFilters.delete(title);
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
    }

    update(param: 'lang' | 'level' | 'topic', eventData: Set<string>) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = eventData;
                break;
            case 'level':
                this.selectedLevelFilters = eventData;
                break;
            case 'topic':
                this.selectedTopicsFilters = eventData;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
    }

    resetFilters() {
        this.resetFiltersEvent.next();
        this.selectedLevelFilters = new Set();
        this.selectedTopicsFilters = new Set();
        this.selectedLanguagesFilters = new Set();
    }
}
