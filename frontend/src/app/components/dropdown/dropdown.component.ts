import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.sass']
})
export class DropdownComponent implements OnInit {
  @Input() data: any[];
  @Input() btnLabel: string | undefined;
  @Output() selectedFilters = new EventEmitter<Set<string>>();
  @Input() resetEvent: Observable<void>;

  public withLabel = false;

  public showDropdown = false;

  public selectedItems = new Set<string>();

  constructor() { }

  ngOnInit(): void {
    this.resetEvent.subscribe(() => {
      this.selectedItems = new Set();
    })

    this.withLabel = this.data[0].hasOwnProperty('subtitle');
  }

  selectItem(title: string){
    if(this.selectedItems.has(title)){
      this.selectedItems.delete(title);
      this.selectedFilters.emit(this.selectedItems)
    }
    else{
      this.selectedItems.add(title);
      this.selectedFilters.emit(this.selectedItems)
    }
  }

  showDropdownMenu(){
    this.showDropdown = !this.showDropdown;
  }

  reset(){

  }

}
