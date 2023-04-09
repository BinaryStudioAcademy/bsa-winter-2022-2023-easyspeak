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

    passwordIsMatch: boolean = true;

    passwordIsValid: boolean = true;

    token: string;

    email: string;

    constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService, private toastr: ToastrService) {}

    ngOnInit(): void {
        this.route.queryParams.subscribe((params) => {
            this.token = params['oobCode'];
            this.email = params['email'];
        });
    }

    isSame() {
        this.passwordIsMatch = this.password === this.repeatPassword;
    }

    isValid() {
        this.passwordIsValid = this.passwordPattern.test(this.password);
    }

    async resetPassword() {
        this.isSame();

        this.isValid();

        if (this.passwordIsMatch && this.passwordPattern.test(this.password)) {
            await this.authService.confirmResetPassword(this.token, this.password)
                .then(() => {
                    this.toastr.success('Password have been changed successfully!', 'Change Password');
                    this.SignIn();
                })
                .catch((error) => {
                    this.toastr.error(error.message, 'Change Password error');
                });
        }
    }

    private SignIn() {
        this.authService.signIn(this.email, this.password)
            .then(() => {
                this.router.navigate(['timetable']);
            })
            .catch();
    }
}
