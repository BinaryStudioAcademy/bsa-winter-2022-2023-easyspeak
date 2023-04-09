import { Component } from '@angular/core';
//import { update } from '@angular/fire/database';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { lengthValidator } from '@modules/auth/sign-in/lengthValidator';

@Component({
    selector: 'app-sign-in-example',
    styleUrls: ['./sign-in-example.component.sass'],
    templateUrl: './sign-in-example.component.html',
})
export class SignInExampleComponent {
    myForm: FormGroup;

    constructor() {
        this.myForm = new FormGroup({

            userEmail: new FormControl('', [
                Validators.required,
                lengthValidator(3, 5),
            ]),
        });
    }

    submit() {
        console.log(this.myForm);
    }
}
