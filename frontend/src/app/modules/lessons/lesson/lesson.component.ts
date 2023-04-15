import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseComponent } from '@core/base/base.component';
import { AuthService } from '@core/services/auth.service';
import { SpinnerService } from '@core/services/spinner.service';
import { UserService } from '@core/services/user.service';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { ILesson } from '@shared/models/lesson/ILesson';

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

    questions: string;

    isShowQuestions = true;

    isLoading = false;

    buttonHover: string;

    isLessonAuthor: boolean;

    constructor(
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
        private userService: UserService,
        private spinner: SpinnerService,
        private notificationService: NotificationService,
        private countriesService: CountriesTzLangProviderService,
        private authService: AuthService,
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

    showQuestions() {
        if (this.isQuestionsOpened) {
            this.questions = '';
        } else {
            this.questions = this.lesson.questions;
            this.questionsOpened.emit();
            this.changeCardHeight();
        }
        this.isQuestionsOpened = !this.isQuestionsOpened;
    }

    changeCardHeight() {
        const observer = new MutationObserver(() => {
            const container = document.querySelector('.lesson-card-questions') as HTMLElement;

            if (container) {
                observer.disconnect();

                if (container.scrollHeight > container.clientHeight) {
                    container.style.height = '460px';
                }
            }
        });

        observer.observe(document.body, { childList: true, subtree: true });
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

        this.authService.user.subscribe(
            u => {
                this.isLessonAuthor = (u.id === this.lesson.user.id);
            },
        );
    }

    isDisabled() {
        if (this.isTeachersPage || (!this.isTeachersPage && this.isLessonAuthor)) {
            return this.lesson.isCanceled;
        }
        if (!this.isTeachersPage) {
            return (
                this.lesson.isSubscribed ||
                new Date() > new Date(this.lesson.startAt) ||
                this.lesson.limitOfUsers === null ||
                this.lesson.subscribersCount === this.lesson.limitOfUsers
            );
        }

        return false;
    }

    getButtonContent() {
        switch (true) {
            case (this.isTeachersPage || (!this.isTeachersPage && this.isLessonAuthor)):
                if (!this.lesson.isCanceled) {
                    this.buttonHover = 'hover';

                    return 'Cancel';
                }

                return 'Canceled';

            case !this.isTeachersPage:
                if (new Date() > new Date(this.lesson.startAt)) {
                    return 'Expired';
                }
                if (this.lesson.isSubscribed) {
                    return 'Subscribed';
                }

                this.buttonHover = 'hover';

                return 'Join';

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
