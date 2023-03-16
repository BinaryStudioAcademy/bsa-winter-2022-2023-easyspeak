/* eslint-disable no-restricted-syntax */
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

    private validationErrorMessage: { [id: string]: string } = {
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

    getErrorMessage(field: string) {
        for (const message in this.validationErrorMessage) {
            if (this.form.controls[field].hasError(message)) {
                return this.validationErrorMessage[message];
            }
        }

        return '';
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
