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
            topics: [],
            langLevels: [],
            language: null,
            compatibility: 0,
        } as UserFilter;
    }

    get hasFilters(): boolean {
        return !!this.selectedLanguagesFilters.size
            || !!this.selectedCompatibilityFilters.size
            || !!this.selectedLevelFilters.size
            || !!this.selectedTopicsFilters.size;
    }

    remove(param: 'compatibility' | 'lang' | 'level' | 'topic', title: string) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters.delete(title);
                // eslint-disable-next-line prefer-destructuring
                this.userFilters.language = [...this.selectedLanguagesFilters][0];
                break;
            case 'level':
                this.selectedLevelFilters.delete(title);
                this.userFilters.langLevels = [...this.selectedLevelFilters];
                break;
            case 'topic':
                this.selectedTopicsFilters.delete(title);
                this.userFilters.topics = [...this.selectedTopicsFilters];
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters.delete(title);
                this.userFilters.compatibility = this.selectedCompatibilityFilters.size !== 0 ?
                    +[...this.selectedCompatibilityFilters][0] : null;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    update(param: 'compatibility' | 'lang' | 'level' | 'topic', eventData: Set<string> | string[]) {
        const setEventData = new Set(eventData);
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = setEventData;
                // eslint-disable-next-line prefer-destructuring
                this.userFilters.language = [...this.selectedLanguagesFilters][0];
                break;
            case 'level':
                this.selectedLevelFilters = setEventData;
                this.userFilters.langLevels = [...this.selectedLevelFilters];
                break;
            case 'topic':
                this.selectedTopicsFilters = setEventData;
                this.userFilters.topics = [...this.selectedTopicsFilters];
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters = setEventData;
                this.userFilters.compatibility = this.selectedCompatibilityFilters.size !== 0 ?
                    +[...this.selectedCompatibilityFilters][0] : null;
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
