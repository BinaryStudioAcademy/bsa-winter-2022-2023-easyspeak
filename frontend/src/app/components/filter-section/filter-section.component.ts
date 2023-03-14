import { Component, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import {topicsSample, langLevelsSample} from 'src/app/components/filter-section/filter-section.util'
import { Filter } from 'src/app/models/filters/filter';

@Component({
  selector: 'app-filter-section',
  templateUrl: './filter-section.component.html',
  styleUrls: ['./filter-section.component.sass']
})
export class FilterSectionComponent implements OnInit {
  resetFiltersEvent: Subject<void> = new Subject<void>();

  public langBtnLabel = 'Level';
  public topicsBtnLabel = 'Interests'

  public selectedLanguageFilters = new Set<string>();
  public selectedTopicsFilters = new Set<string>();

  public topics: Filter[];
  public langLevels: Filter[]

  constructor() { }

  ngOnInit(): void {
    this.topics = topicsSample.map(x => {
      return {
        title: x.title
      }
    });

    this.langLevels = langLevelsSample.map(x => {
        return {
          title: x.title,
          subtitle: x.subtitle,
          description: x.description
        }
    })
  }

  removeLangLevel(title: string){
    this.selectedLanguageFilters.delete(title);
  }

  removeTopic(title: string){
    this.selectedTopicsFilters.delete(title);
  }

  updateLangFilters(eventData: Set<string>){
    this.selectedLanguageFilters = eventData;
  }

  updateTopicFilters(eventData: Set<string>){
    this.selectedTopicsFilters = eventData;
  }

  resetFilters(){
    this.resetFiltersEvent.next();
    this.selectedLanguageFilters = new Set();
    this.selectedTopicsFilters = new Set();
  }

}
