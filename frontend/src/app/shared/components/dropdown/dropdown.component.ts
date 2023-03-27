import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/base/base.component';
import { Observable } from 'rxjs';

import { Filter } from 'src/app/models/filters/filter';

@Component({
    selector: 'app-dropdown',
    templateUrl: './dropdown.component.html',
    styleUrls: ['./dropdown.component.sass'],
})
export class DropdownComponent extends BaseComponent implements OnInit, OnDestroy {
    @Input() data: Filter[];

    @Input() isSingleChoice: boolean;

    type: string;

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
        this.type = this.isSingleChoice ? 'radio' : 'checkbox';
    }

    selectItem(title: string) {
        if (this.selectedItems.has(title)) {
            this.selectedItems.delete(title);
        } else if (this.isSingleChoice) {
            this.selectSingle(title);
        } else {
            this.selectMultiple(title);
        }
        this.selectedFilters.emit(this.selectedItems);
    }

    selectMultiple(title: string) {
        this.selectedItems.add(title);
    }

    selectSingle(title: string) {
        this.selectedItems.clear();
        this.selectedItems.add(title);
    }

    showDropdownMenu() {
        this.showDropdown = !this.showDropdown;
    }
}
