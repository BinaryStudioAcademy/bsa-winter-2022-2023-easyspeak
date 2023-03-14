import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-filter-section',
  templateUrl: './filter-section.component.html',
  styleUrls: ['./filter-section.component.sass']
})
export class FilterSectionComponent implements OnInit {

  public showLangDropdown = false;
  public showTopicsDropdown = false;

  public selectedLanguageCount = 0;
  public selectedTopicsCount = 0;

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

  selectLanguage(){
    this.showLangDropdown = !this.showLangDropdown;
  }

  selectInterests(){
    this.showTopicsDropdown = !this.showTopicsDropdown;
  }

  selectLangLevel(title: any){
    if(this.selectedLanguageFilters.has(title)){
      this.selectedLanguageFilters.delete(title);
    }
    else{
      this.selectedLanguageFilters.add(title);
    }
    console.log(this.selectedLanguageFilters.size);
  }

  selectTopic(title: any){
    if(this.selectedTopicsFilters.has(title)){
      this.selectedTopicsFilters.delete(title);
    }
    else{
      this.selectedTopicsFilters.add(title);
    }
    console.log(this.selectedLanguageFilters);
  }

  closeAllFilters(){
    this.selectedLanguageFilters = new Set();
    this.selectedTopicsFilters = new Set();
  }

}
