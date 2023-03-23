import { Component } from '@angular/core';
import Utils from '@shared/utils/lesson.utils';

@Component({
    selector: 'app-lessons-page',
    templateUrl: './lessons-page.component.html',
    styleUrls: ['./lessons-page.component.sass'],
})
export class LessonsPageComponent {
    lessons = Utils.lessons;
}
