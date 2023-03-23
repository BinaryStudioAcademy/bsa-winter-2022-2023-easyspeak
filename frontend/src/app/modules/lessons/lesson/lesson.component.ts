import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';

import { Question } from 'src/app/models/lessons/question';
import { LessonsService } from 'src/app/services/lessons.service';

import { LessonsCreateComponent } from '../lessons-create/lessons-create.component';

@Component({
    selector: 'app-lesson',
    templateUrl: './lesson.component.html',
    styleUrls: ['./lesson.component.sass'],
})
export class LessonComponent {
    //temporary solution, will be changed to Lesson interface
    //eslint-disable-next-line @typescript-eslint/no-explicit-any
    @Input() lesson: any;

    questions: Question[] = [];

    constructor(private dialogRef: MatDialog, private lessonsService: LessonsService) {}

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

    openCreate() {
        this.dialogRef.open(LessonsCreateComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
        });
    }

    getQuestions(id: number) {
        this.lessonsService.getQuestions(id).subscribe((questions) => {
            this.questions = questions as Question[];
        });
    }
}
