import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseComponent } from '@core/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';
import { UserService } from '@core/services/user.service';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';

import { Lesson } from 'src/app/models/lessons/lesson';
import { Question } from 'src/app/models/lessons/question';
import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lesson',
    templateUrl: './lesson.component.html',
    styleUrls: ['./lesson.component.sass'],
})
export class LessonComponent extends BaseComponent {
    @Input() lesson: Lesson;

    questions: Question[] = [];

    isShowQuestions = true;

    constructor(
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
        private userService: UserService,
        private spinner: SpinnerService,
        private notificationService: NotificationService,
    ) {
        super();
    }

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

    showQuestions(id: number) {
        if (this.isShowQuestions) {
            this.getQuestions(id);
        }

        if (this.questions.length) {
            this.isShowQuestions = !this.isShowQuestions;
        }
    }

    private getQuestions(id: number) {
        this.spinner.show();
        this.lessonsService.getQuestions(id).subscribe((questions) => {
            this.questions = questions as Question[];
            this.spinner.hide();
        });
    }

    enrollLesson() {
        this.userService.enrollUserToLesson(this.lesson.id)
            .pipe(this.untilThis)
            .subscribe({ next: (lesson) => {
                this.lesson.isDisabled = true;
                this.lesson.subscribersCount = lesson.subscribersCount;
                this.notificationService.showSuccess(`You successfully registered for lesson ${this.lesson.title}`, 'Success!');
            },
            error: () => this.notificationService.showError(`Failed to register for lesson ${this.lesson.title}`, 'Failed!') });
    }
}
