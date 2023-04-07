import { Component } from '@angular/core';
//import { update } from '@angular/fire/database';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { createPasswordStrengthValidator } from '@modules/auth/sign-in/createPasswordStrengthValidator';

@Component({
    selector: 'app-sign-in-example',
    styleUrls: ['./sign-in-example.component.sass'],
    templateUrl: './sign-in-example.component.html',
})
export class SignInExampleComponent {
    myForm: FormGroup;

    constructor() {
        this.myForm = new FormGroup({

            userName: new FormControl('', {
                validators: [Validators.required],
                updateOn: 'blur',
            }),
            userEmail: new FormControl('', [
                Validators.required,
                // Validators.email,
                createPasswordStrengthValidator(2),
            ]),
            userPhone: new FormControl('', Validators.pattern('[0-9]{10}')),
        });
    }

    submit() {
        console.log(this.myForm);
    }

    userNameValidator(control: FormControl): { [s: string]: boolean } | null {
        if (control.value === 'нет') {
            return { userName: true };
        }

        return null;
    }
}
