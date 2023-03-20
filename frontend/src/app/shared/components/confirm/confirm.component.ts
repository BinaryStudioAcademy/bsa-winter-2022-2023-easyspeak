import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IConfirm } from '@shared/models/IConfirm';

@Component({
    selector: 'app-confirm',
    templateUrl: './confirm.component.html',
    styleUrls: ['./confirm.component.sass'],
})
export class ConfirmComponent {
    constructor(@Inject(MAT_DIALOG_DATA) public data: IConfirm) {
    }
}
