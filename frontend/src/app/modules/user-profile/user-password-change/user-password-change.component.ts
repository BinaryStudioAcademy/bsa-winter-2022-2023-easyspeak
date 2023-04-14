import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@core/services/auth.service';
import { passFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

import { validationErrorMessage } from 'src/app/modules/user-profile/user-password-change/error-helper';

import { matchpassword } from './matchpassword.validator';

@Component({
    selector: 'app-user-password-change',
    templateUrl: './user-password-change.component.html',
    styleUrls: ['./user-password-change.component.sass'],
})
export class UserPasswordChangeComponent {
    warningOn: boolean = false;

    passwordForm: FormGroup;

    passwordPattern: RegExp = new RegExp(passFormatRegex);

    constructor(private authService: AuthService, private toastr: ToastrService) {
        this.passwordForm = new FormGroup(
            {
                currentPassword: new FormControl(
                    '',
                    [Validators.required,
                        Validators.minLength(6),
                        Validators.maxLength(25),
                        Validators.pattern(passFormatRegex)],
                ),
                newPassword: new FormControl(
                    '',
                    [Validators.required,
                        Validators.minLength(6),
                        Validators.maxLength(25),
                        Validators.pattern(passFormatRegex)],
                ),
                repeatPassword: new FormControl(
                    '',
                    [Validators.required,
                        Validators.minLength(6),
                        Validators.maxLength(25),
                        Validators.pattern(passFormatRegex)],
                ),
            },
            { validators: matchpassword },
        );
    }

    onSaveNewPassword() {
        this.warningOn = true;

        if (this.isAllValid()) {
            this.savePassword();
        } else {
            this.toastr.error('Validation error', 'Error');
        }
    }

    isAllValid() {
        return (
            this.isSame() &&
            this.currentPassword.valid &&
            this.newPassword.valid &&
            this.currentPassword.value !== this.newPassword.value);
    }

    savePassword() {
        this.authService.saveNewPassword(this.currentPassword.value, this.newPassword.value)
            .then(() => {
                this.toastr.success('New password has been saved!', 'Save Password');
            })
            .catch((error) => {
                this.toastr.error(error.message, 'Error');
                this.toastr.error('Current password is wrong', 'Save Password');
            });
    }

    isSame = () => this.newPassword.value === this.repeatPassword.value;

    newAsOldPassword = () => this.newPassword.value && this.newPassword.value === this.currentPassword.value;

    getErrorMessage(control: FormControl): string {
        const errorEntry = Object.entries(validationErrorMessage)
            .find(([key]) => control.hasError(key));

        if (errorEntry) {
            return errorEntry[1];
        }

        return '';
    }

    get currentPassword(): FormControl {
        return this.passwordForm.get('currentPassword') as FormControl;
    }

    get newPassword(): FormControl {
        return this.passwordForm.get('newPassword') as FormControl;
    }

    get repeatPassword(): FormControl {
        return this.passwordForm.get('repeatPassword') as FormControl;
    }
}
