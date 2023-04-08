import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseComponent } from '@core/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';
import { UserService } from '@core/services/user.service';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { ILesson } from '@shared/models/lesson/ILesson';

import { Question } from 'src/app/models/lessons/question';
import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';
import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lesson',
    templateUrl: './lesson.component.html',
    styleUrls: ['./lesson.component.sass'],
})
export class LessonComponent extends BaseComponent implements OnInit {
    @Input() lesson: ILesson;

    previewImage: string;

    questions: Question[] = [];

    isShowQuestions = true;

    isLoading = false;

    constructor(
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
        private userService: UserService,
        private spinner: SpinnerService,
        private notificationService: NotificationService,
        private countriesService: CountriesTzLangProviderService,
    ) {
        super();
    }

    openDialog(youtubeVideoId: string) {
        if (!youtubeVideoId) {
            return;
        }
        this.dialogRef.open(YoutubePlayerComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
            data: {
                youtubeVideoId,
            },
        });
    }

    showQuestions(id: number) {
        if (this.questions.length) {
            this.isShowQuestions = !this.isShowQuestions;
        }

        if (this.isShowQuestions) {
            this.getQuestions(id);
        }
    }

    private getQuestions(id: number) {
        this.isLoading = true;
        this.spinner.show();
        this.lessonsService.getQuestions(id).subscribe((questions) => {
            this.questions = questions as Question[];
            this.isLoading = false;
            this.spinner.hide();
        });
    }

    enrollLesson() {
        this.userService
            .enrollUserToLesson(this.lesson.id)
            .pipe(this.untilThis)
            .subscribe({
                next: (lesson) => {
                    this.lesson.isSubscribed = true;
                    this.lesson.subscribersCount = lesson.subscribersCount;
                    this.notificationService.showSuccess(
                        `You successfully registered for lesson ${this.lesson.name}`,
                        'Success!',
                    );
                },
                error: () =>
                    this.notificationService.showError(`Failed to register for lesson ${this.lesson.name}`, 'Failed!'),
            });
    }

    ngOnInit(): void {
        this.previewImage = this.lesson.youtubeVideoId
            ? `//img.youtube.com/vi/${this.lesson.youtubeVideoId}/maxresdefault.jpg`
            : '';
    }

    isDisabled() {
        return this.lesson.isSubscribed || new Date() > new Date(this.lesson.startAt);
    }

    getButtonContent() {
        if (new Date() > new Date(this.lesson.startAt)) {
            return 'Expired';
        }
        if (this.lesson.isSubscribed) {
            return 'Subscribed';
        }

        return 'Join';
    }

    getFlag(): string | undefined {
        return this.countriesService.getUserCountryFlag(this.lesson.user.country);
    }
}
