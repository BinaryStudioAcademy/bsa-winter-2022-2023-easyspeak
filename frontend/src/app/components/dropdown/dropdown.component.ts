import { Component, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Observable, Subject, takeUntil } from 'rxjs';
import { Filter } from 'src/app/models/filters/filter';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.sass']
})
export class DropdownComponent implements OnInit, OnDestroy {
  @Input() data: Filter[];
  @Input() btnLabel: string | undefined;
  @Output() selectedFilters = new EventEmitter<Set<string>>();
  @Input() resetEvent: Observable<void>;


  public showDropdown = false;

  public selectedItems = new Set<string>();

  private unsubscribe$ = new Subject<void>();

  constructor() { }

  ngOnInit(): void {
    this.resetEvent
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(() => {
      this.selectedItems = new Set();
    });
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  selectItem(title: string){
    if(this.selectedItems.has(title)){
      this.selectedItems.delete(title);
    }
    else{
      this.selectedItems.add(title);
    }

    this.selectedFilters.emit(this.selectedItems)
  }

  showDropdownMenu(){
    this.showDropdown = !this.showDropdown;
  }

}
