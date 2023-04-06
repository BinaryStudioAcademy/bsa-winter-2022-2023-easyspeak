import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AuthService } from '@core/services/auth.service';
import { LessonsCreateComponent } from '@modules/lessons/lessons-create/lessons-create.component';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { IModal } from '@shared/models/IModal';
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

        this.lessonsService.getTeacherStatistics().subscribe((data) => {
            this.statistics = data as TeacherStatistics;
            if (this.statistics.nextClass) {
                const datePipe = new DatePipe('en-US');

                this.statistics.nextClass = datePipe.transform(this.statistics.nextClass, 'd MMMM yyyy, EEE');
            }
        });

        this.displayWeek();
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

    displayToday() {
        console.log('display today');
    }

    displayWeek() {
        console.log('display week');
    }

    displayMonth() {
        console.log('display month');
    }
}
