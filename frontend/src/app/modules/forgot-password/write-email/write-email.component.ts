import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { emailFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-write-email',
    templateUrl: './write-email.component.html',
    styleUrls: ['./write-email.component.sass'],
})
export class WriteEmailComponent {
    email: string = '';

    isMatchFormat: boolean = true;

    buttonClicked: boolean = false;

    constructor(private router: Router, private authService: AuthService, private toastr: ToastrService) {}

    async sendMail() {
        this.isMatchFormat = emailFormatRegex.test(this.email);

        this.buttonClicked = true;

        if (this.isMatchFormat) {
            await this.authService.resetPassword(this.email)
                .then(() => {
                    this.toastr.success('Recovery link has been send to your email', 'Email send');
                    this.router.navigate(['auth/forgot-password/check-email']);
                })
                .catch((error) => {
                    this.toastr.error(error.message, 'Email send error');
                });
        }
    }

    changedMail(): void {
        this.isMatchFormat = emailFormatRegex.test(this.email);

        this.buttonClicked = false;
    }

    redWarning(): boolean {
        if (!this.isMatchFormat && this.buttonClicked && this.email.length > 0) {
            return true;
        }

        return false;
    }
}
