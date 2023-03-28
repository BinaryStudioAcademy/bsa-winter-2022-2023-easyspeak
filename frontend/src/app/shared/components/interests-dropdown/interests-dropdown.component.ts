import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/base/base.component';
import { IIcon } from '@shared/models/IIcon';
import { getTags } from '@shared/utils/tagsForInterests';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-interests-dropdown',
    templateUrl: './interests-dropdown.component.html',
    styleUrls: ['./interests-dropdown.component.sass'],
})
export class InterestsDropdownComponent extends BaseComponent implements OnInit {
    toggle: boolean = false;

    @Input() inputList: IIcon[] = getTags();

    @Input() resetEvent?: Observable<void>;

    @Output() selectedInterests = new EventEmitter<string[]>();

    outputList: string[] = [];

    ngOnInit() {
        if (this.resetEvent) {
            this.resetEvent
                .pipe(this.untilThis)
                .subscribe(() => {
                    this.outputList = [];
                });
        }
    }

    selectInterest($event: Event) {
        const ev = $event.target as HTMLInputElement;
        const numb = parseInt(ev.id, 10);
        const { checked } = ev;

        if (checked) {
            this.outputList = this.outputList.concat(this.inputList[numb].icon_name);
        } else {
            this.outputList = this.outputList.filter(x => x !== this.inputList[numb].icon_name);
        }

        this.selectedInterests.emit(this.outputList);
    }

    clickButton() {
        this.toggle = !this.toggle;
    }
}
