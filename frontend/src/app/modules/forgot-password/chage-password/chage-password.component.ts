import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '@core/services/auth.service';

@Component({
    selector: 'app-chage-password',
    templateUrl: './chage-password.component.html',
    styleUrls: ['./chage-password.component.sass'],
})
export class ChagePasswordComponent implements OnInit {
    password: string = '';

    repeatPassword: string = '';

    showPassword: boolean = false;

    showRepeatPassword: boolean = false;

    passwordIsMatch: boolean = true;

    token: string;

    constructor(private route: ActivatedRoute, private authService: AuthService) {}

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => { this.token = params['oobCode']; console.log(this.token); });
    }

    togglePassword(inShow: boolean) {
        this.showPassword = inShow;
    }

    toggleRepeatPassword(inShow: boolean) {
        this.showRepeatPassword = inShow;
    }

    isSame() {
        if (this.repeatPassword.length === 0) {
            this.passwordIsMatch = true;
        } else {
            this.passwordIsMatch = this.password === this.repeatPassword;
        }
        if (this.passwordIsMatch) {
            this.authService.confirmResetPassword(this.token, this.password);
        }
    }
}
