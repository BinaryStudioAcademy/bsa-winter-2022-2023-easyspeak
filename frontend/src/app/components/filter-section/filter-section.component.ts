import { Component, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import {topicsSample, langLevelsSample} from 'src/app/components/filter-section/filter-section.util'

@Component({
  selector: 'app-filter-section',
  templateUrl: './filter-section.component.html',
  styleUrls: ['./filter-section.component.sass']
})
export class FilterSectionComponent implements OnInit {
  resetFiltersEvent: Subject<void> = new Subject<void>();

  public langBtnLabel = 'Level';
  public topicsBtnLabel = 'Interests'

  public selectedLanguageFilters = new Set();
  public selectedTopicsFilters = new Set();

  public topics = topicsSample;
  public langLevels = langLevelsSample;

  constructor() { }

  ngOnInit(): void {
  }

  removeLangLevel(title: any){
    this.selectedLanguageFilters.delete(title);
  }

  removeTopic(title: any){
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
