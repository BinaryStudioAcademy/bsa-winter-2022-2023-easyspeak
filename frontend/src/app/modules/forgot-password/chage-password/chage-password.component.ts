import { Component } from '@angular/core';

@Component({
    selector: 'app-chage-password',
    templateUrl: './chage-password.component.html',
    styleUrls: ['./chage-password.component.sass'],
})
export class ChagePasswordComponent {
    password: string = '';

    repeatPassword: string = '';

    showPassword: boolean = false;

    showRepeatPassword: boolean = false;

    passwordIsMatch: boolean = true;

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
    }
}
