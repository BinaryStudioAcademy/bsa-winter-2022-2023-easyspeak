import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@core/services/auth.service';
import { ToastrService } from 'ngx-toastr';

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

    constructor(private formBuilder: FormBuilder, private authService: AuthService, private toastr: ToastrService) {}

    getErrorMessage(field: string) {
        const errorEntry = Object.entries(this.validationErrorMessage).find(([key]) => this.form.controls[field].hasError(key));

        return errorEntry ? errorEntry[1] : '';
    }

    validationThenSignIn() {
        this.submitted = true;
        this.validateData();

        if (!this.form.invalid) {
            this.signIn();
        }
    }

    private signIn() {
        this.authService
            .signIn(this.email, this.password)
            .then(() => {
                this.toastr.success('Successfully sign in', 'Sign in');
            })
            .catch((error) => {
                this.toastr.error(error.message, 'Sign up');
            });
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
