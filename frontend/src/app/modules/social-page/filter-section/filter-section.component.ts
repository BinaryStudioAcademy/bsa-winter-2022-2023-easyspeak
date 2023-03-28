import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
    compatibilities,
    langLevelsSample,
    topicsSample,
} from '@modules/filter-section/filter-section/filter-section.util';
import { Subject } from 'rxjs';

import { Filter } from '../../../models/filters/filter';
import { UserFilter } from '../../../models/filters/userFilter';
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

    public compatibilities: Filter[];

    public userFilters: UserFilter;

    @Output()
        filterChange = new EventEmitter<UserFilter>();

    ngOnInit(): void {
        this.topics = topicsSample;
        this.langLevels = langLevelsSample;
        this.compatibilities = compatibilities.map(c => ({ title: c.toString() }));
        this.languages = this.languageTimezone.getLanguagesList().map(language => ({ title: language }));
        this.userFilters = {
            topics: new Set<string>(),
            langLevels: new Set<string>(),
            languages: new Set<string>(),
            compatibilities: new Set<string>(),
        } as UserFilter;
    }

    remove(param: 'compatibility' | 'lang' | 'level' | 'topic', title: string) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters.delete(title);
                this.userFilters.languages = this.selectedLanguagesFilters;
                break;
            case 'level':
                this.selectedLevelFilters.delete(title);
                this.userFilters.langLevels = this.selectedLevelFilters;
                break;
            case 'topic':
                this.selectedTopicsFilters.delete(title);
                this.userFilters.topics = this.selectedTopicsFilters;
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters.delete(title);
                this.userFilters.compatibilities = this.selectedCompatibilityFilters;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    update(param: 'compatibility' | 'lang' | 'level' | 'topic', eventData: Set<string>) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = eventData;
                this.userFilters.languages = this.selectedLanguagesFilters;
                break;
            case 'level':
                this.selectedLevelFilters = eventData;
                this.userFilters.langLevels = this.selectedLevelFilters;
                break;
            case 'topic':
                this.selectedTopicsFilters = eventData;
                this.userFilters.topics = this.selectedTopicsFilters;
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters = eventData;
                this.userFilters.compatibilities = this.selectedCompatibilityFilters;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();
        this.selectedLevelFilters = new Set();
        this.selectedTopicsFilters = new Set();
        this.selectedLanguagesFilters = new Set();
        this.selectedCompatibilityFilters = new Set();
    }
}
