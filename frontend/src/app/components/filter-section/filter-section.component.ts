import { Component, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';

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

  public topics = [
    {
      title: 'Traveling',
    },
    {
      title: 'Music',
    },
    {
      title: 'Films',
    },
    {
      title: 'Cars',
    },
    {
      title: 'Architecture',
    },
    {
      title: 'Arts',
    },
    {
      title: 'Celebreties',
    }
  ];

  public langLevels = [
    {
      title: 'B1',
      subtitle: 'Intermadiate',
      desc: 'I am beginning to able to express myself clearly'
    },
    {
      title: 'A1',
      subtitle: 'Beginner',
      desc: 'I am complete beginner'
    },
    {
      title: 'A2',
      subtitle: 'Pre-Intermadiate',
      desc: 'I have some experience, but I still can not express myself properly'
    },
    {
      title: 'B2',
      subtitle: 'Upper-Intermadiate',
      desc: 'I feel confident in using English'
    },
    {
      title: 'C1',
      subtitle: 'Advanced',
      desc: 'I have a lot of experience and I feel that I can help someone to learn language'
    },
    {
      title: 'C2',
      subtitle: 'Proficient',
      desc: 'I am fluent at English'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

  selectLangLevel(title: any){
    if(this.selectedLanguageFilters.has(title)){
      this.selectedLanguageFilters.delete(title);
    }
    else{
      this.selectedLanguageFilters.add(title);
    }
  }

  selectTopic(title: any){
    if(this.selectedTopicsFilters.has(title)){
      this.selectedTopicsFilters.delete(title);
    }
    else{
      this.selectedTopicsFilters.add(title);
    }
  }

  closeAllFilters(){
    this.selectedLanguageFilters = new Set();
    this.selectedTopicsFilters = new Set();

    
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
