import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { passFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-change-password',
    templateUrl: './change-password.component.html',
    styleUrls: ['./change-password.component.sass'],
})
export class ChangePasswordComponent implements OnInit {
    passwordPattern: RegExp = new RegExp(passFormatRegex);

    password: string = '';

    repeatPassword: string = '';

    showPassword: boolean = false;

    showRepeatPassword: boolean = false;

    passwordIsMatch: boolean = true;

    token: string;

    email: string;

    responseIsOk: boolean = true;

    constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService, private toastr: ToastrService) {}

    ngOnInit(): void {
        this.route.queryParams.subscribe((params) => {
            this.token = params['oobCode'];
        });
        this.route.queryParams.subscribe((params) => {
            this.email = params['email'];
        });
    }

    togglePassword(isShow: boolean) {
        this.showPassword = isShow;
    }

    toggleRepeatPassword(isShow: boolean) {
        this.showRepeatPassword = isShow;
    }

    async isSame() {
        this.passwordIsMatch = this.password === this.repeatPassword;
    }

    async resetPassword() {
        this.isSame();

        if (this.passwordIsMatch && this.passwordPattern.test(this.password)) {
            const response = this.authService.confirmResetPassword(this.token, this.password);

            if ((await response) === true) {
                this.authService.signIn(this.email, this.password);

                this.toastr.success('Password have been changed successfully!', 'Success');

                this.router.navigate(['main']);
            } else {
                this.responseIsOk = false;
            }
        }
    }
}
