import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  isSocialPageActive: boolean;
  isTimetablePageActive: boolean;

  ngOnInit(): void {
  }

  setSocialActivePage() {
    this.isSocialPageActive = true;
    this.isTimetablePageActive = false;
  }

  setTimetableActivePage() {
    this.isTimetablePageActive = true;
    this.isSocialPageActive = false;
  }

}
