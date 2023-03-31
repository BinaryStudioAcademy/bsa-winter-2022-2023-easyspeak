import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-write-email',
    templateUrl: './write-email.component.html',
    styleUrls: ['./write-email.component.sass'],
})
export class WriteEmailComponent {
    emailPattern: RegExp = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/;

    email: string = '';

    isMatch: boolean = true;

    wrongEmail: boolean = false;

    constructor(private router: Router, private authService: AuthService, private toastr: ToastrService) {}

    async sendMail(): Promise<void> {
        this.isMatch = this.emailPattern.test(this.email);

        if (this.isMatch) {
            const goNextPage: Promise<boolean> = this.authService.resetPassword(this.email);

            if ((await goNextPage) === true) {
                this.toastr.success('Recovery link has been send to your email', 'Success');
                this.router.navigate(['auth/forgot-password/check-email']);
            } else {
                this.toastr.error('User with this email doesnt exist', 'Error');
                this.wrongEmail = true;
            }
        }
    }

    changedMail(): void {
        this.isMatch = true;
    }
}
