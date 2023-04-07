import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { emailFormatRegex, passFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

import { validationErrorMessage } from '../sign-up/error-helper';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.sass'],
})
export class SignInComponent {
    form: FormGroup = new FormGroup({
        email: new FormControl('', [
            Validators.required,
            Validators.maxLength(50),
            Validators.minLength(3),
            Validators.pattern(emailFormatRegex),
        ]),
        password: new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(25),
            Validators.pattern(passFormatRegex),
        ]),
    });

    doesntExist: boolean;

    wrongPassword: boolean;

    clearErrorMessage: boolean;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private toastr: ToastrService,
        private router: Router,
    ) {
    }

    public signIn() {
        this.clearErrorMessage = false;
        if (this.lengthError(this.email) || this.lengthError(this.password) || this.email.errors?.['pattern']) { return; }
        this.authService
            .signIn(this.email.value, this.password.value)
            .then(() => {
                this.toastr.success('Successfully sign in', 'Sign in');
                this.router.navigate(['timetable']);
            })
            .catch((error) => {
                this.wrongPassword = error.code === 'auth/wrong-password';
                this.doesntExist = error.code === 'auth/user-not-found';
                if (this.doesntExist) {
                    this.email.setErrors({ signInEmailNotFound: true });
                }
                this.toastr.error(error.message, 'Sign up');
            });
    }

    getErrorMessage(control: FormControl): string {
        const errorEntry = Object.entries(validationErrorMessage)
            .find(([key]) => control.hasError(key));

        if (errorEntry) {
            return errorEntry[1];
        }

        return '';
    }

    get email(): FormControl {
        return this.form.get('email') as FormControl;
    }

    get password(): FormControl {
        return this.form.get('password') as FormControl;
    }

    ////
    lengthError(item: FormControl) {
        const error = item.errors?.['required'] || item.errors?.['minlength'] || item.errors?.['maxlength'];

        this.email.setErrors({ signInEmailNotFound: true });

        return error;
    }

    ////
    onFocus() {
        this.clearErrorMessage = true;
    }
}
