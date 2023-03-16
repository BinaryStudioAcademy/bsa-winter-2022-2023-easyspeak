import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent {
    EnglishLevels = [
        'A1 (Elementary)',
        'A2 (Elementary)',
        'B1 (Intermediate)',
        'B2 (Intermediate)',
        'C1 (Advanced)',
        'C2 (Advanced)',
    ];

    Ages = ['5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18'];

    Countries = ['Ukraine', 'Austria', 'England', 'Scotland', 'Poland', 'Romania'];

    private validationErrorMessage = {
        required: 'Enter a value',
        maxlength: "Can't be more than 25 characters",
        email: 'Not a valid email',
        minlength: "Can't be less 2 symbols",
        pattern: 'Should be at least one small and one capital letter',
    };

    email = '';

    firstName: string = '';

    lastName: string = '';

    password: string = '';

    confirmPassword: string = '';

    submitted = false;

    form: FormGroup = new FormGroup({
        firstName: new FormControl(this.firstName),
        lastName: new FormControl(this.lastName),
        email: new FormControl(this.email),
        password: new FormControl(this.password),
        confirmPassword: new FormControl(this.confirmPassword),
    });

    constructor(private formBuilder: FormBuilder) {}

    getEmailErrorMessage() {
        if (this.form.controls['email'].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        if (this.form.controls['email'].hasError('email')) {
            return this.validationErrorMessage.email;
        }

        return this.form.controls['email'].hasError('maxlength') ? 'Can not be more than 30 characters' : '';
    }

    getPasswordErrorMessage() {
        if (this.form.controls['password'].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        if (this.form.controls['password'].hasError('minlength')) {
            return 'Can not be less than 6 symbols';
        }

        if (this.form.controls['password'].hasError('pattern')) {
            return this.validationErrorMessage.pattern;
        }

        return this.form.controls['password'].hasError('maxlength') ? this.validationErrorMessage.maxlength : '';
    }

    getConfirmPasswordErrorMessage() {
        if (this.form.controls['confirmPassword'].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        return this.confirmPassword !== this.password ? 'The password does not match' : '';
    }

    getNameErrorMessage(field: string) {
        if (this.form.controls[field].hasError('required')) {
            return this.validationErrorMessage.required;
        }

        if (this.form.controls[field].hasError('minlength')) {
            return this.validationErrorMessage.minlength;
        }

        return this.form.controls[field].hasError('maxlength') ? this.validationErrorMessage.maxlength : '';
    }

    validation() {
        this.submitted = true;
        this.validateData();
    }

    private validateData() {
        this.form = this.formBuilder.group({
            firstName: [this.firstName, [Validators.required, Validators.minLength(2), Validators.maxLength(25)]],
            lastName: [this.lastName, [Validators.required, Validators.minLength(2), Validators.maxLength(25)]],
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
            confirmPassword: [this.confirmPassword, Validators.required],
        });
    }
}
