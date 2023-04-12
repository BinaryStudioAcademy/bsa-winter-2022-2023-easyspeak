import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DataService } from '@core/services/data.service';
import {
    compatibilities,
    langLevelsSample,
} from '@modules/filter-section/filter-section/filter-section.util';
import { IIcon } from '@shared/models/IIcon';
import { Subject } from 'rxjs';

import { Filter } from '../../../models/filters/filter';
import { UserFilter } from '../../../models/filters/userFilter';

type FilterOption = 'compatibility' | 'lang' | 'level';

@Component({
    selector: 'app-filter-section',
    templateUrl: './filter-section.component.html',
    styleUrls: ['./filter-section.component.sass'],
})
export class FilterSectionComponent implements OnInit {
    public constructor(private dataService: DataService) {}

    resetFiltersEvent: Subject<void> = new Subject<void>();

    public selectedLevelFilters: string[] = [];

    public selectedLevelWithSubtitleFilters: string[] = [];

    public selectedTopicsFilters: IIcon[] = [];

    public selectedLanguagesFilters: string[] = [];

    public selectedCompatibilityFilters: string[] = [];

    public topics: IIcon[];

    public langLevels: Filter[];

    public languages: Filter[];

    public compatibilities: Filter[];

    public userFilters: UserFilter;

    @Output() filterChange = new EventEmitter<UserFilter>();

    ngOnInit(): void {
        this.dataService.getAllTags().subscribe((tags) => {
            this.topics = tags.map((tag): IIcon => ({
                ...tag,
                link: `assets/topic-icons/${tag.imageUrl}`,
            }));
        });
        this.langLevels = langLevelsSample;
        this.compatibilities = compatibilities.map((c) => ({ title: c.toString() }));
        this.userFilters = {} as UserFilter;
        this.dataService.getAllLanguages().subscribe((languages) => {
            this.languages = languages.map((l): Filter => ({ title: l }));
        });
    }

    get hasFilters(): boolean {
        return (
            !!this.selectedLanguagesFilters.length ||
            !!this.selectedCompatibilityFilters.length ||
            !!this.selectedLevelFilters.length ||
            !!this.selectedTopicsFilters.length
        );
    }

    removeTopic(topic: IIcon) {
        this.selectedTopicsFilters = this.selectedTopicsFilters.filter((s) => s !== topic);
        this.userFilters.topics = this.selectedTopicsFilters;
    }

    remove(param: FilterOption, title: string) {
        const splitedTitle = title.split(':');

        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = this.selectedLanguagesFilters.filter((s) => s !== title);
                this.userFilters.language = null;
                break;
            case 'level':
                this.selectedLevelFilters = this.selectedLevelFilters.filter((s) => s !== splitedTitle[0]);
                this.userFilters.langLevels = this.selectedLevelFilters;
                this.selectedLevelWithSubtitleFilters = this.getLanguageLevelWithSubtitle();
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters = this.selectedCompatibilityFilters.filter((s) => s !== title);
                this.userFilters.compatibility = null;
                break;
            default:
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    updateTopics(eventData: IIcon[]) {
        this.selectedTopicsFilters = eventData;
        this.userFilters.topics = this.selectedTopicsFilters;
        this.filterChange.emit(this.userFilters);
    }

    update(param: FilterOption, eventData: string[]) {
        switch (param) {
            case 'lang':
                this.selectedLanguagesFilters = eventData;
                [this.userFilters.language] = eventData;
                break;
            case 'level':
                this.selectedLevelFilters = eventData;
                this.userFilters.langLevels = this.selectedLevelFilters;
                this.selectedLevelWithSubtitleFilters = this.getLanguageLevelWithSubtitle();
                break;
            case 'compatibility':
                this.selectedCompatibilityFilters = eventData;
                this.userFilters.compatibility = Number(this.selectedCompatibilityFilters[0]) ?? null;
                break;
            default:
                break;
        }
        this.filterChange.emit(this.userFilters);
    }

    resetFilters() {
        this.resetFiltersEvent.next();
        this.selectedLevelFilters = [];
        this.selectedLevelWithSubtitleFilters = [];
        this.selectedTopicsFilters = [];
        this.selectedLanguagesFilters = [];
        this.selectedCompatibilityFilters = [];
        this.userFilters = {} as UserFilter;
        this.filterChange.emit(this.userFilters);
    }

    private getLanguageLevelWithSubtitle() {
        return this.selectedLevelFilters.map((f) => {
            const level = this.langLevels.find((l) => l.title === f);

            return `${level?.title}: ${level?.subtitle}`;
        });
    }
}
