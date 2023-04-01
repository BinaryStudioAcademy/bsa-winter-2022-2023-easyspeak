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

    isMatchFormat: boolean = true;

    isWrongEmail: boolean = false;

    buttonClicked: boolean = false;

    constructor(private router: Router, private authService: AuthService, private toastr: ToastrService) {}

    async sendMail(): Promise<void> {
        this.isMatchFormat = emailFormatRegex.test(this.email);

        this.buttonClicked = true;

        if (this.isMatchFormat) {
            const goNextPage: Observable<boolean> = await this.authService.resetPassword(this.email);

            this.resetPassSub = (await goNextPage).subscribe((success) => {
                if (success) {
                    this.toastr.success('Recovery link has been send to your email', 'Success');

                    this.router.navigate(['auth/forgot-password/check-email']);
                } else {
                    this.isWrongEmail = true;
                }
            });
        } else if (this.email.length === 0) {
            this.isMatchFormat = true;
        }
    }

    changedMail(): void {
        this.isMatchFormat = emailFormatRegex.test(this.email);

        this.buttonClicked = false;

        if (this.isWrongEmail) {
            this.isWrongEmail = false;
        }
    }

    redWarning(): boolean {
        if (!this.isMatchFormat && this.buttonClicked && this.email.length > 0) {
            return true;
        }

        return false;
    }

    ngOnDestroy() {
        if (this.resetPassSub) {
            this.resetPassSub.unsubscribe();
        }
    }
}
