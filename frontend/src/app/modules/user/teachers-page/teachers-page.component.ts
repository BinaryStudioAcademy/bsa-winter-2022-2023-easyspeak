import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AuthService } from '@core/services/auth.service';
import { applyTimeOffset, filterColumn } from '@modules/lessons/lesson/lesson.helper';
import { LessonsCreateComponent } from '@modules/lessons/lessons-create/lessons-create.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { IModal } from '@shared/models/IModal';
import { IDateWithLessons } from '@shared/models/lesson/IDateWithLessons';
import { UserShort } from '@shared/models/UserShort';

import { TeacherStatistics } from 'src/app/models/lessons/teacher-statistics';
import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-teachers-page',
    templateUrl: './teachers-page.component.html',
    styleUrls: ['./teachers-page.component.sass'],
})
export class TeachersPageComponent implements OnInit {
    currentUser: UserShort = {
        email: '',
        firstName: '',
        lastName: '',
        imagePath: '',
    };

    statistics: TeacherStatistics = {
        totalClasses: 0,
        canceledClasses: 0,
        futureClasses: 0,
        totalStudents: 0,
        nextClass: null,
    };

    datesWithLessons: IDateWithLessons[] = [];

    constructor(
        private authService: AuthService,
        private dialogRef: MatDialog,
        private lessonsService: LessonsService,
    ) {}

    ngOnInit(): void {
        this.authService.user.subscribe((user) => {
            this.currentUser = user;
        });

        this.lessonsService.getTeacherStatistics().subscribe((data) => {
            this.statistics = data;
        });

        this.loadLessons(7);
    }

    openCreate() {
        const config: MatDialogConfig<IModal> = {
            data: {
                header: 'Add Group Class',
                hasButtons: false,
                component: LessonsCreateComponent,
            },
        };

        this.dialogRef.open(ModalComponent, config);
    }

    loadLessons(daysCount: number) {
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
}
