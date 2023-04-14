import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.sass'],
})
export class PaginationComponent {
    @Input() lastPage: number = 3;

    @Output() pageNumberChanged = new EventEmitter<number>();

    currentPage: number = 1;

    onChoose = (inNumber: number) => {
        this.currentPage = inNumber;
        this.onChanged();
    };

    incCurrent() {
        if (this.currentPage < this.lastPage) {
            this.currentPage++;
            this.onChanged();
        }
    }

    decCurrent() {
        if (this.currentPage > 1) {
            this.currentPage--;
            this.onChanged();
        }
    }

    onChanged = () => this.pageNumberChanged.emit(this.currentPage);

    getLeft = () => (this.currentPage > 1 ? this.currentPage - 1 : 1);

    getRight = () => (this.currentPage < this.lastPage ? this.currentPage + 1 : this.lastPage);
}
