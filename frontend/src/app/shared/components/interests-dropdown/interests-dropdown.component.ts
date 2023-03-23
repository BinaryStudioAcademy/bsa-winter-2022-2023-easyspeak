import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IIcon } from '@shared/models/IIcon';
import { TagsForInterests } from '@shared/utils/tagsForInterests';

@Component({
    selector: 'app-interests-dropdown',
    templateUrl: './interests-dropdown.component.html',
    styleUrls: ['./interests-dropdown.component.sass'],
})
export class InterestsDropdownComponent {
    toggle: boolean = false;

    @Input() inputList: IIcon[] = TagsForInterests.tags;

    @Output() selectedInterests = new EventEmitter<string[]>();

    outputList: string[] = [];

    selectInterest($event: Event) {
        const ev = $event.target as HTMLInputElement;
        const numb = parseInt(ev.id, 10);
        const { checked } = ev;

        if (checked) {
            this.outputList.push(this.inputList[numb].icon_name);
        } else {
            this.outputList = this.outputList.filter(x => x !== this.inputList[numb].icon_name);
        }

        this.selectedInterests.emit(this.outputList);
    }

    clickButton() {
        this.toggle = !this.toggle;
    }
}
