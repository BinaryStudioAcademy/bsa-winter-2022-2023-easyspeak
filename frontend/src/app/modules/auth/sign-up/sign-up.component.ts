/* eslint-disable no-restricted-syntax */
import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@core/services/auth.service';
import { HttpService } from '@core/services/http.service';
import { INewUser } from '@shared/models/INewUser';
import { IUser } from '@shared/models/IUser';
import { ToastrService } from 'ngx-toastr';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent implements OnDestroy {
    EnglishLevels = ['A1', 'A2', 'B1', 'B2', 'C1', 'C2'];

    Ages = ['5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18'];

    Countries = ['Ukraine', 'Austria', 'England', 'Scotland', 'Poland', 'Romania'];

    private validationErrorMessage: { [id: string]: string } = {
        required: 'Enter a value',
        maxlength: "Can't be more than 25 characters",
        email: 'Not a valid email',
        minlength: "Can't be less 2 symbols",
        pattern: 'Should be at least one small and one capital letter',
    };

    newUser: INewUser = {
        firstName: '',
        lastName: '',
        email: '',
        age: 0,
        sex: '',
        languageLevel: '',
        country: '',
        language: '',
    };

    private unsubscribe$ = new Subject<void>();

    password: string = '';

    confirmPassword: string = '';

    currentUser: IUser = {
        firstName: '',
        lastName: '',
        email: '',
    };

    isValid = true;

    submitted = false;

    form: FormGroup = new FormGroup({
        firstName: new FormControl(this.newUser.firstName),
        lastName: new FormControl(this.newUser.lastName),
        email: new FormControl(this.newUser.email),
        password: new FormControl(this.password),
        confirmPassword: new FormControl(this.confirmPassword),
    });

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private toastr: ToastrService,
        private httpService: HttpService,
    ) {}

    public ngOnDestroy() {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }

    signUp() {
        if (!this.form.invalid && this.isValid) {
            this.authService
                .signUp(this.newUser.email, this.password)
                .then(() => {
                    this.httpService
                        .post<INewUser>('/users', this.newUser)
                        .pipe(takeUntil(this.unsubscribe$))
                        .subscribe((result) => {
                            this.currentUser = result;
                        });

                    this.toastr.success('Successfully sign up', 'Sign up');
                })
                .catch((error) => {
                    this.toastr.error(error.message, 'Sign up');
                });
        }
    }

    getErrorMessage(field: string) {
        this.validateData();

        for (const message in this.validationErrorMessage) {
            if (this.form.controls[field].hasError(message)) {
                return this.validationErrorMessage[message];
            }
        }

        return this.form.controls['email'].hasError('maxlength') ? 'Can not be more than 30 characters' : '';
    }

    getPasswordErrorMessage() {
        for (const message in this.validationErrorMessage) {
            if (this.form.controls['password'].hasError(message)) {
                return this.validationErrorMessage[message];
            }
        }

        return this.form.controls['password'].hasError('minlength') ? 'Can not be less than 6 symbols' : '';
    }

    getConfirmPasswordErrorMessage() {
        if (this.form.controls['confirmPassword'].hasError('required')) {
            this.isValid = false;

            return this.validationErrorMessage['required'];
        }

        if (this.confirmPassword !== this.password) {
            this.isValid = false;

            return 'The password does not match';
        }

        return '';
    }

    validation() {
        this.submitted = true;
        this.validateData();
    }

    private validateData() {
        this.form = this.formBuilder.group({
            firstName: [
                this.newUser.firstName,
                [Validators.required, Validators.minLength(2), Validators.maxLength(25)],
            ],
            lastName: [this.newUser.lastName, [Validators.required, Validators.minLength(2), Validators.maxLength(25)]],
            email: [this.newUser.email, [Validators.required, Validators.email, Validators.maxLength(30)]],
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
