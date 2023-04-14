import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.sass'],
})
export class PaginationComponent {
    @Input() pageCount: number;

    @Output() pageNumberChanged = new EventEmitter<number>();

    currentPage: number = 1;

    onChoose(selectedPage: number) {
        this.currentPage = selectedPage;
        this.onChanged();
    }

    incCurrent() {
        if (this.currentPage < this.pageCount) {
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

    onChanged = () => this.pageNumberChanged.emit(this.currentPage - 1);

    getLeft = () => (this.currentPage > 1 ? this.currentPage - 1 : 1);

    getRight = () => (this.currentPage < this.pageCount ? this.currentPage + 1 : this.pageCount);
}
