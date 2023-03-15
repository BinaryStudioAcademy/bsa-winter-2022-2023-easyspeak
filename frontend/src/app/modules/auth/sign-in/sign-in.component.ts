import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.sass'],
})
export class SignInComponent {
    password: string = '';

    email = '';

    submitted = false;

    form: FormGroup = new FormGroup({
        email: new FormControl(this.email),
        password: new FormControl(this.password),
    });

    constructor(private formBuilder: FormBuilder) {}

    getEmailErrorMessage() {
        if (this.form.controls['email'].hasError('required')) {
            return 'You must enter a value';
        }

        if (this.form.controls['email'].hasError('email')) {
            return 'Not a valid email';
        }

        return this.form.controls['email'].hasError('maxlength') ? 'Can not be more than 30 characters' : '';
    }

    getPasswordErrorMessage() {
        if (this.form.controls['password'].hasError('required')) {
            return 'Enter a value';
        }

        if (this.form.controls['password'].hasError('minlength')) {
            return 'Can not be less than 2 symbols';
        }

        if (this.form.controls['password'].hasError('pattern')) {
            return 'Should be at least one small and one capital letter';
        }

        return this.form.controls['password'].hasError('maxlength') ? 'Can not be more than 25 symbols' : '';
    }

    validation() {
        this.submitted = true;
        this.validateData();
    }

    private validateData() {
        this.form = this.formBuilder.group({
            email: [this.email, [Validators.required, Validators.email, Validators.maxLength(30)]],
            password: [this.password, [Validators.required]],
        });
    }
}
