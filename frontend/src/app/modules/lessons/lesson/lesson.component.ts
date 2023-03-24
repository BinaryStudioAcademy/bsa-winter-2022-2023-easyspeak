import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SpinnerService } from '@core/services/spinner.service';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';

import { Lesson } from 'src/app/models/lessons/lesson';
import { Question } from 'src/app/models/lessons/question';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-lesson',
    templateUrl: './lesson.component.html',
    styleUrls: ['./lesson.component.sass'],
    template: '<app-loading-spinner></app-loading-spinner>',
})
export class LessonComponent {
    @Input() lesson: Lesson;

    questions: Question[] = [];

    constructor(
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
        private spinner: SpinnerService,
    ) {}

    openDialog(videoId: string) {
        this.dialogRef.open(YoutubePlayerComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
            data: {
                videoId,
            },
        });
    }

    getQuestions(id: number) {
        this.spinner.show();
        this.lessonsService.getQuestions(id).subscribe(
            (questions) => {
                this.questions = questions as Question[];
                this.spinner.hide();
            },
            () => {
                this.spinner.hide();
            },
        );
    }
}
