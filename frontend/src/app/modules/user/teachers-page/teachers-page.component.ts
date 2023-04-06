import { Component, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { UserShort } from '@shared/models/UserShort';

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

    totalClasses = 0;

    canceledClasses = 0;

    futureClasses = 0;

    totalStudents = 0;

    nextClass = 'No classes planned';

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        this.authService.loadUser().subscribe();

        this.authService.user.subscribe((user) => {
            this.currentUser = user;
        });
    }
}
