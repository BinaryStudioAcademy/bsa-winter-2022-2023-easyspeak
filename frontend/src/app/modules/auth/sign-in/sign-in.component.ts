import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { emailRegex, passwordRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

import { validationErrorMessage } from '../sign-up/error-helper';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.sass'],
})
export class SignInComponent {
    form: FormGroup = new FormGroup({
        email: new FormControl('', {
            validators: [Validators.minLength(3), Validators.maxLength(50), Validators.pattern(emailRegex), Validators.required],
            updateOn: 'submit',
        }),
        password: new FormControl('', {
            validators: [Validators.pattern(passwordRegex), Validators.required],
            updateOn: 'submit',
        }),
    });

    isChanged = false;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private toastr: ToastrService,
        private router: Router,
    ) { }

    public signIn() {
        this.isChanged = true;
        if (this.form.valid) {
            this.authService
                .signIn(this.email.value, this.password.value)
                .then(() => {
                    this.toastr.success('Successfully sign in', 'Sign in');
                    this.router.navigate(['timetable']);
                })
                .catch((error) => {
                    const errorMessage: string | undefined = this.getFireBaseMessage(error.code);

                    this.toastr.error(errorMessage, 'Sign up');
                });
        }
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

    ClearErrors() {
        this.isChanged = false;
    }

    GetErrorMessageByKey(id: string) {
        return Object.entries(validationErrorMessage).find(([t]) => t === id)?.[1];
    }

    getFireBaseMessage(code: string) {
        switch (code) {
            case 'auth/user-not-found':
                return this.GetErrorMessageByKey('notExists');
            case 'auth/wrong-password':
                return this.GetErrorMessageByKey('incorrectPassword');
            default: return undefined;
        }
    }

    CheckCondition(control: FormControl, cond: string) {
        if (cond === 'required') {
            return ((control.errors?.[cond] && control.touched) || control.pristine) && this.isChanged;
        }
        if (cond === 'pattern') {
            return control.errors?.[cond] && this.isChanged;
        }
    }
}
