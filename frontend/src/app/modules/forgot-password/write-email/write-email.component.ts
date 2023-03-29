import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';

@Component({
    selector: 'app-write-email',
    templateUrl: './write-email.component.html',
    styleUrls: ['./write-email.component.sass'],
})
export class WriteEmailComponent {
    emailPattern: RegExp = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    email: string = '';

    isMatch: boolean = true;

    constructor(private router: Router, private authService: AuthService) {}

    checkMail(): void {
        this.isMatch = this.emailPattern.test(this.email);
        if (this.isMatch) {
            this.authService.resetPassword(this.email);
            this.router.navigate(['forgot-password/check-email']);
        }
    }

    changedMail(): void {
        this.isMatch = true;
    }
}
