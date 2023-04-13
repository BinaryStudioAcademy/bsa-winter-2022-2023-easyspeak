import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

    @Input() isTeachersPage: boolean;

    @Input() isQuestionsOpened: boolean;

    @Output() questionsOpened = new EventEmitter<void>();

    previewImage: string;

    questions: Question[] = [];

    isLoading = false;

    buttonHover: string;

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

    openDialog(videoId: string) {
        if (!videoId) {
            return;
        }
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
        if (this.questions.length > 0 && this.isQuestionsOpened) {
            this.questions = [];
            this.isQuestionsOpened = false;
        } else {
            this.isQuestionsOpened = true;
            this.getQuestions(id);
            this.questionsOpened.emit();

            const observer = new MutationObserver(() => {
                const container = document.querySelector('.lesson-card-questions') as HTMLElement;

                if (
                    container &&
                    document.querySelector('.question-text') &&
                    document.querySelectorAll('.lesson-card-questions').length === 1
                ) {
                    observer.disconnect();

                    if (container.scrollHeight > container.clientHeight) {
                        container.style.height = '460px';
                    }
                }
            });

            observer.observe(document.body, { childList: true, subtree: true });
        }
    }

    private getQuestions(id: number) {
        this.isLoading = true;
        this.spinner.show();
        this.lessonsService.getQuestions(id).subscribe((questions) => {
            this.questions = questions;
            this.isLoading = false;
            this.spinner.hide();
        });
    }

    joinLesson() {
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

    cancelLesson() {
        this.lessonsService.cancelLesson(this.lesson.id, this.lesson).subscribe((data) => {
            this.lesson.isCanceled = data.isCanceled;
        });
    }

    ngOnInit(): void {
        this.previewImage = this.lesson.youtubeVideoId
            ? `//img.youtube.com/vi/${this.lesson.youtubeVideoId}/maxresdefault.jpg`
            : '';
    }

    isDisabled() {
        if (!this.isTeachersPage) {
            return (
                this.lesson.isSubscribed ||
                new Date() > new Date(this.lesson.startAt) ||
                this.lesson.limitOfUsers === null ||
                this.lesson.subscribersCount === this.lesson.limitOfUsers
            );
        }
        if (this.isTeachersPage) {
            return this.lesson.isCanceled || new Date() > new Date(this.lesson.startAt);
        }

        return false;
    }

    getButtonContent() {
        switch (true) {
            case !this.isTeachersPage:
                if (new Date() > new Date(this.lesson.startAt)) {
                    return 'Expired';
                }
                if (this.lesson.isSubscribed) {
                    return 'Subscribed';
                }

                this.buttonHover = 'join-hover';

                return 'Join';

            case this.isTeachersPage:
                if (!this.lesson.isCanceled) {
                    return 'Cancel';
                }

                return 'Canceled';

            default:
                return '';
        }
    }

    getFlag(): string | undefined {
        return this.countriesService.getUserCountryFlag(this.lesson.user.country);
    }

    editLesson() {
        if (!this.lesson.isCanceled) {
            //TODO: implement edit lesson
        }
    }
}
