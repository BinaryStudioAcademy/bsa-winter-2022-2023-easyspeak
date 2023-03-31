import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { emailFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';

@Component({
    selector: 'app-write-email',
    templateUrl: './write-email.component.html',
    styleUrls: ['./write-email.component.sass'],
})
export class WriteEmailComponent implements OnDestroy {
    private resetPassSub: Subscription;

    email: string = '';

    isMatch: boolean = true;

    wrongEmail: boolean = false;

    constructor(private router: Router, private authService: AuthService, private toastr: ToastrService) {}

    async sendMail(): Promise<void> {
        this.isMatch = emailFormatRegex.test(this.email);

        if (this.isMatch) {
            const goNextPage: Promise<Observable<boolean>> = this.authService.resetPassword(this.email);

            this.resetPassSub = (await goNextPage).subscribe((success) => {
                if (success) {
                    this.toastr.success('Recovery link has been send to your email', 'Success');

                    this.router.navigate(['auth/forgot-password/check-email']);
                } else {
                    this.wrongEmail = true;
                }
            });
        } else if (this.email.length === 0) {
            this.isMatch = true;
        }
    }

    changedMail(): void {
        if (this.email.length === 0) {
            this.isMatch = true;
        } else
        if (!this.isMatch) {
            this.isMatch = emailFormatRegex.test(this.email);
        }
        if (this.wrongEmail) {
            this.wrongEmail = false;
        }
    }

    ngOnDestroy() {
        if (this.resetPassSub) {
            this.resetPassSub.unsubscribe();
        }
    }
}
