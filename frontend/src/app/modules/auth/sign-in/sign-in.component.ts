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

    private validationErrorMessage = {
        required: 'Enter a value',
        maxlength: 'Can not be more than 30 characters',
        email: 'Not a valid email',
        minlength: "Can't be less 6 symbols",
        pattern: 'Should be at least one small and one capital letter',
    };

    form: FormGroup = new FormGroup({
        email: new FormControl(this.email),
        password: new FormControl(this.password),
    });

    constructor(private formBuilder: FormBuilder) {}

    getEmailErrorMessage() {
        if (this.form.controls['email'].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        if (this.form.controls['email'].hasError('email')) {
            return this.validationErrorMessage.email;
        }

        return this.form.controls['email'].hasError('maxlength') ? this.validationErrorMessage.maxlength : '';
    }

    getPasswordErrorMessage() {
        if (this.form.controls['password'].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        if (this.form.controls['password'].hasError('minlength')) {
            return this.validationErrorMessage.minlength;
        }

        if (this.form.controls['password'].hasError('pattern')) {
            return this.validationErrorMessage.pattern;
        }

        return this.form.controls['password'].hasError('maxlength') ? 'Can not be more than 25 characters' : '';
    }

    validation() {
        this.submitted = true;
        this.validateData();
    }

    private validateData() {
        this.form = this.formBuilder.group({
            email: [this.email, [Validators.required, Validators.email, Validators.maxLength(30)]],
            password: [
                this.password,
                [
                    Validators.required,
                    Validators.minLength(6),
                    Validators.maxLength(25),
                    Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\\d@$!%*?&\\.]{6,}$'),
                ],
            ],
        });
    }
}
