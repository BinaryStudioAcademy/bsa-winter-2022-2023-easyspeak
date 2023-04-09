import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { lengthValidator } from '@modules/auth/sign-in/lengthValidator';
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
        email: new FormControl('', {
            validators: [lengthValidator(3, 50), Validators.pattern(emailFormatRegex), Validators.required],

            updateOn: 'submit',
        }),
        password: new FormControl('', {
            validators: [lengthValidator(6, 25), Validators.pattern(passFormatRegex), Validators.required],
            updateOn: 'submit',
        }),
    });

    isSubmitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private toastr: ToastrService,
        private router: Router,
    ) {
    }

    public signIn() {
        this.isSubmitted = true;
        if (this.email.valid && this.password.valid) {
            this.authService
                .signIn(this.email.value, this.password.value)
                .then(() => {
                    this.toastr.success('Successfully sign in', 'Sign in');
                    this.router.navigate(['timetable']);
                })
                .catch((error) => {
                    if (error.code === 'auth/user-not-found') {
                        this.email.setErrors({ emailNotFound: true });
                    }
                    if (error.code === 'auth/wrong-password') {
                        this.password.setErrors({ wrongPassword: true });
                    }
                    this.toastr.error(error.message, 'Sign up');
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

    ClearRemoteErrors(control: FormControl) {
        this.isSubmitted = false;
        // control.setErrors(null);
        //this.password.setErrors({ wrongPassword: null });
    }
}
