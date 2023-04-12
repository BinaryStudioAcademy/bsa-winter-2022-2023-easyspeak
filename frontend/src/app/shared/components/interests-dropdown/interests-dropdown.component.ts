import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { DataService } from '@core/services/data.service';
import { IIcon } from '@shared/models/IIcon';

@Component({
    selector: 'app-interests-dropdown',
    templateUrl: './interests-dropdown.component.html',
    styleUrls: ['./interests-dropdown.component.sass'],
})
export class InterestsDropdownComponent implements OnChanges, OnInit {
    toggle = false;

    inputList: IIcon[];

    @Output() selectedInterests = new EventEmitter<IIcon[]>();

    @Input() selectedItems: IIcon[] = [];

    @Input() usedInModal = false;

    outputList: IIcon[] = [];

    constructor(private dataService: DataService) {
    }

    ngOnInit(): void {
        this.dataService.getAllTags().subscribe((tags) => {
            this.inputList = tags.map((tag): IIcon => ({
                id: tag.id,
                name: tag.name,
                link: `assets/topic-icons/${tag.imageUrl}`,
            }));
        });
    }

    ngOnChanges() {
        this.outputList = this.selectedItems;
    }

    selectInterest($event: Event) {
        const ev = $event.target as HTMLInputElement;
        const numb = parseInt(ev.id, 10);
        const { checked } = ev;

        if (checked) {
            this.outputList = [...this.outputList, this.inputList[numb]];
        } else {
            this.outputList = this.outputList.filter((interest) => interest !== this.inputList[numb]);
        }

        this.selectedInterests.emit(this.outputList);
    }

    iconExistsInOutputList(icon: IIcon): boolean {
        return this.outputList.some(item => item.name === icon.name);
    }

    clickButton() {
        this.toggle = !this.toggle;
    }

    clickedOutside() {
        this.toggle = false;
    }
}
