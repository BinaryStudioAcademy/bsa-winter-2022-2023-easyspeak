import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { IIcon } from '@shared/models/IIcon';
import { getTags } from '@shared/utils/tagsForInterests';

@Component({
    selector: 'app-interests-dropdown',
    templateUrl: './interests-dropdown.component.html',
    styleUrls: ['./interests-dropdown.component.sass'],
})
export class InterestsDropdownComponent implements OnChanges {
    toggle = false;

    @Input() inputList: IIcon[] = getTags();

    @Output() selectedInterests = new EventEmitter<string[]>();

    @Input() selectedItems: string[];

    outputList: string[] = [];

    ngOnChanges() {
        this.outputList = this.selectedItems;
    }

    selectInterest($event: Event) {
        const ev = $event.target as HTMLInputElement;
        const numb = parseInt(ev.id, 10);
        const { checked } = ev;

        if (checked) {
            this.outputList = [...this.outputList, this.inputList[numb].icon_name];
        } else {
            this.outputList = this.outputList.filter((interest) => interest !== this.inputList[numb].icon_name);
        }

        this.selectedInterests.emit(this.outputList);
    }

    iconExistsInOutputList(icon: string): boolean {
        return this.outputList.some(item => item === icon);
    }

    clickButton() {
        this.toggle = !this.toggle;
    }
}
