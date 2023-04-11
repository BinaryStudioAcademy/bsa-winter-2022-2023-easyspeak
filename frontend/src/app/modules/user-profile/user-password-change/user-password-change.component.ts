import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { passFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-user-password-change',
    templateUrl: './user-password-change.component.html',
    styleUrls: ['./user-password-change.component.sass'],
})
export class UserPasswordChangeComponent {
    passwordPattern: RegExp = new RegExp(passFormatRegex);

    currentPassword: string;

    newPassword: string;

    repeatPassword: string;

    isSame: boolean = true;

    isValid: boolean = true;

    isCurrentValid: boolean = true;

    constructor(private router: Router, private authService: AuthService, private toastr: ToastrService) {}

    onSaveNewPassword() {
        this.checkPasswords();

        if (this.isAllValid()) {
            this.savePassword();
        } else {
            this.showError();
        }
    }

    showError() {
        switch (true) {
            case !this.isSame:
                this.toastr.error('Password/Repeat password don’t match', 'Save Password');
                break;
            case this.currentPassword !== this.newPassword:
                this.toastr.error('New password is the same as current', 'Save Password');
                break;
            case (!this.currentPassword || !this.newPassword || !this.repeatPassword):
                this.toastr.error('Field is required', 'Save Password');
                break;
            case !this.isValid || !this.isCurrentValid:
                this.toastr.error('Password is not valid format!', 'Save Password');
                break;
            default:
                this.toastr.error('Something gone wrong!', 'Save Password');
                break;
        }
    }

    isAllValid() {
        return this.isSame && this.isValid && this.isCurrentValid && this.currentPassword !== this.newPassword;
    }

    checkPasswords() {
        this.isSame = this.newPassword === this.repeatPassword;
        this.isValid = this.passwordPattern.test(this.newPassword);
        this.isCurrentValid = this.passwordPattern.test(this.currentPassword);
    }

    warningReset() {
        this.isSame = true;
        this.isValid = true;
        this.isCurrentValid = true;
    }

    savePassword() {
        this.authService.saveNewPassword(this.currentPassword, this.newPassword)
            .then(() => {
                this.toastr.success('New password has been saved!', 'Save Password');
                this.router.navigate(['timetable']);
            })
            .catch((error) => {
                this.toastr.error(error.message, 'Error');
                this.toastr.error('Current password is wrong', 'Save Password');
            });
    }
}
