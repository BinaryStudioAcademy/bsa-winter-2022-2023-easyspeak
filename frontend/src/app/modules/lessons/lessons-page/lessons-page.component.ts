import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import Utils from '@shared/utils/lesson.utils';

import { LessonsCreateComponent } from '../lessons-create/lessons-create.component';

@Component({
    selector: 'app-lessons-page',
    templateUrl: './lessons-page.component.html',
    styleUrls: ['./lessons-page.component.sass'],
})
export class LessonsPageComponent {
    lessons = Utils.lessons;

    constructor(private dialogRef: MatDialog) {}

    openCreate() {
        this.dialogRef.open(LessonsCreateComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
        });
    }
}
