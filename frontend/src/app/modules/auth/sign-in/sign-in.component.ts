import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { passFormatRegex } from '@shared/data/regex.util';
import { ToastrService } from 'ngx-toastr';

import { validationErrorMessage } from '../sign-up/error-helper';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.sass'],
})
export class SignInComponent {
    form: FormGroup = new FormGroup({
        email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(30)]),
        password: new FormControl(
            '',
            [
                Validators.required,
                Validators.minLength(6),
                Validators.maxLength(25),
                Validators.pattern(passFormatRegex),
            ],
        ),
    });

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private toastr: ToastrService,
        private router: Router,
    ) {}

    public signIn() {
        this.authService
            .signIn(this.email.value, this.password.value)
            .then(() => {
                this.toastr.success('Successfully sign in', 'Sign in');
                this.router.navigate(['timetable']);
            })
            .catch((error) => {
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
}
