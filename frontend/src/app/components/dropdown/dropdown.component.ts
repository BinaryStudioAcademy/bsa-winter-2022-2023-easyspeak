import { Component, Input, OnDestroy, OnInit, Output, EventEmitter } from '@angular/core';
import { BaseComponent } from '@core/base/base.component';
import { Observable, Subject, takeUntil } from 'rxjs';
import { Filter } from 'src/app/models/filters/filter';

@Component({
    selector: 'app-dropdown',
    templateUrl: './dropdown.component.html',
    styleUrls: ['./dropdown.component.sass'],
})
export class DropdownComponent extends BaseComponent implements OnInit, OnDestroy {
    @Input() data: Filter[];
    @Input() btnLabel: string | undefined;
    @Output() selectedFilters = new EventEmitter<Set<string>>();
    @Input() resetEvent: Observable<void>;

    public showDropdown = false;

    public selectedItems = new Set<string>();

    ngOnInit(): void {
        this.resetEvent
        .pipe(this.untilThis)
        .subscribe(() => {
          this.selectedItems = new Set();
        });
    }

    selectItem(title: string){
        if (this.selectedItems.has(title)) {
            this.selectedItems.delete(title);
        }
        else {
            this.selectedItems.add(title);
        }

        this.selectedFilters.emit(this.selectedItems);
    }

    showDropdownMenu(){
        this.showDropdown = !this.showDropdown;
    }
}
