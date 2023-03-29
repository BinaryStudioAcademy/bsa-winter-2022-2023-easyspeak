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

    public selectedLevelFilters: string[] = [];

    public selectedTopicsFilters: string[] = [];

    public selectedLanguagesFilters: string[] = [];

    public selectedCompatibilityFilters: string[] = [];

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
        this.userFilters = {} as UserFilter;
    }

    get hasFilters(): boolean {
        return !!this.selectedLanguagesFilters.length
            || !!this.selectedCompatibilityFilters.length
            || !!this.selectedLevelFilters.length
            || !!this.selectedTopicsFilters.length;
    }

    remove(param: 'compatibility' | 'lang' | 'level' | 'topic', title: string) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = this.selectedLanguagesFilters.filter(s => s !== title);
                this.userFilters.language = null;
                break;
            case 'level':
                this.selectedLevelFilters = this.selectedLevelFilters.filter(s => s !== title);
                this.userFilters.langLevels = this.selectedLevelFilters;
                break;
            case 'topic':
                this.selectedTopicsFilters = this.selectedTopicsFilters.filter(s => s !== title);
                this.userFilters.topics = this.selectedTopicsFilters;
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters = this.selectedCompatibilityFilters.filter(s => s !== title);
                this.userFilters.compatibility = this.selectedCompatibilityFilters.length !== 0 ?
                    +this.selectedCompatibilityFilters[0] : null;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    update(param: 'compatibility' | 'lang' | 'level' | 'topic', eventData: string[]) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = eventData;
                [this.userFilters.language] = eventData;
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
                this.userFilters.compatibility = this.selectedCompatibilityFilters.length !== 0 ?
                    +this.selectedCompatibilityFilters[0] : null;
                break;
            default:
                console.error('No such filtering parameter');
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();
        this.selectedLevelFilters = [];
        this.selectedTopicsFilters = [];
        this.selectedLanguagesFilters = [];
        this.selectedCompatibilityFilters = [];
        this.userFilters = {} as UserFilter;
        this.filterChange.emit(this.userFilters);
    }
}
