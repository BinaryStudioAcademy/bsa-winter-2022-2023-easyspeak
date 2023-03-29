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

    @Output() selectedFilters = new EventEmitter<string[]>();

    @Input() resetEvent: Observable<void>;

    @Input() selectedItems: string[] = [];

    public showDropdown = false;

    ngOnInit(): void {
        this.resetEvent
            .pipe(this.untilThis)
            .subscribe(() => {
                this.selectedItems = [];
            });

        this.type = this.isSingleChoice ? 'radio' : 'checkbox';
    }

    selectItem(title: string) {
        if (this.selectedItems.includes(title)) {
            this.selectedItems = this.selectedItems.filter(item => item !== title);
        } else if (this.isSingleChoice) {
            this.selectedItems = [title];
        } else {
            this.selectedItems = [...this.selectedItems, title];
        }

        this.selectedFilters.emit(this.selectedItems);
    }

    showDropdownMenu() {
        this.showDropdown = !this.showDropdown;
    }
}
