import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AuthService } from '@core/services/auth.service';
import { applyTimeOffset, filterColumn } from '@modules/lessons/lesson/lesson.helper';
import { LessonsCreateComponent } from '@modules/lessons/lessons-create/lessons-create.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { IModal } from '@shared/models/IModal';
import { IUserShort } from '@shared/models/IUserShort';
import { IDateWithLessons } from '@shared/models/lesson/IDateWithLessons';

import { TeacherStatistics } from 'src/app/models/lessons/teacher-statistics';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-teachers-page',
    templateUrl: './teachers-page.component.html',
    styleUrls: ['./teachers-page.component.sass'],
})
export class TeachersPageComponent implements OnInit {
    currentUser: IUserShort;

    statistics: TeacherStatistics = {
        totalClasses: 0,
        canceledClasses: 0,
        futureClasses: 0,
        totalStudents: 0,
        nextClass: null,
    };

    selectedDaysCount: number;

    datesWithLessons: IDateWithLessons[] = [];

    openedLessonId: number;

    constructor(
        private authService: AuthService,
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
    ) {}

    ngOnInit(): void {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => {
            this.currentUser = user;
        });

        this.loadStatistics();

        this.loadLessons(7);
    }

    loadStatistics() {
        this.lessonsService.getTeacherStatistics().subscribe((data) => {
            this.statistics = data;
        });
    }

    openCreate() {
        const config: MatDialogConfig<IModal> = {
            data: {
                header: 'Add Group Class',
                hasButtons: false,
                component: LessonsCreateComponent,
            },
        };

        this.dialogRef
            .open(ModalComponent, config)
            .afterClosed()
            .subscribe(() => {
                this.loadLessons(this.selectedDaysCount);
                this.loadStatistics();
            });
    }

    loadLessons(daysCount: number) {
        this.openedLessonId = -1;
        this.selectedDaysCount = daysCount;
        this.lessonsService
            .getTeacherLessonsAtPeriod(
                new Date().toISOString(),
                new Date(new Date().setUTCHours(24 * daysCount, 0, 0, 0)).toISOString(),
            )
            .subscribe((data) => {
                this.datesWithLessons = data;
                this.splitLessons();
            });
    }

    splitLessons() {
        this.datesWithLessons.forEach((dateWithLessons) => {
            dateWithLessons.lessons = applyTimeOffset(dateWithLessons.lessons);
            dateWithLessons.lessonsColumn1 = filterColumn(dateWithLessons.lessons, 1);
            dateWithLessons.lessonsColumn2 = filterColumn(dateWithLessons.lessons, 2);
        });
    }

    onLessonOpenedQuestions(id: number) {
        this.openedLessonId = id;
    }

    isLessonOpenedQuestions(id: number) {
        return this.openedLessonId === id;
    }
}
