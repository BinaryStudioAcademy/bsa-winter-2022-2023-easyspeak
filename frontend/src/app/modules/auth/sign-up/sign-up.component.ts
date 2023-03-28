import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseComponent } from '@core/base/base.component';
import { AuthService } from '@core/services/auth.service';
import { UserService } from '@core/services/user.service';
import { Ages } from '@shared/data/ages.util';
import { EnglishLevel } from '@shared/data/englishLevel';
import { passFormatRegex } from '@shared/data/regex.util';
import { Sex } from '@shared/data/sex';
import { INewUser } from '@shared/models/INewUser';
import { ToastrService } from 'ngx-toastr';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { matchpassword } from './matchpassword.validator';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent extends BaseComponent {
    emglishLevelEnumeration = EnglishLevel;

    sexEnumeration = Sex;

    englishLevels: string[];

    ages: string[];

    countries: string[];

    sexOptions: string[];

    languages: string[];

    registerForm = new FormGroup({
        email: new FormControl('', [Validators.required]),
        firstName: new FormControl('', [Validators.required]),
        lastName: new FormControl('', [Validators.required]),
        sex: new FormControl('', [Validators.required]),
        languageLevel: new FormControl('', [Validators.required]),
        country: new FormControl('', [Validators.required]),
        language: new FormControl('', [Validators.required]),
        dateOfBirth: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required]),
        passwordConfirmation: new FormControl('', [Validators.required, Validators.pattern(passFormatRegex)]),
    }, { validators: matchpassword });

    user: INewUser;

    constructor(
        private formBuilder: FormBuilder,
        private countriesTzLangProvider: CountriesTzLangProviderService,
        private authService: AuthService,
        private toastr: ToastrService,
        private userService: UserService,
        private router: Router,
    ) {
        super();
        this.setUpData();
    }

    submitForm() {
        if (this.validateForm()) {
            this.signUp();
        }
    }

    private setUpData() {
        this.countries = this.countriesTzLangProvider.getCountriesList().map((x) => x.name);
        this.languages = this.countriesTzLangProvider.getLanguagesList();
        this.englishLevels = Object.values(EnglishLevel) as string[];
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.ages = Ages;
    }

    private signUp() {
        this.createUser()
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastr.success('Account successfully registered', 'Succes!');
            });

        this.authService
            .signUp(this.email.value, this.password.value)
            .then(() => {
                this.toastr.success('Successfully sign up', 'Sign up');
                this.router.navigate(['topics']);
            })
            .catch((error) => {
                this.toastr.error(error.message, 'Sign up');
            });
    }

    private validateForm() {
        return this.registerForm.valid;
    }

    private createUser() {
        this.user = {
            firstName: this.firstName.value,
            lastName: this.lastName.value,
            email: this.email.value,
            age: this.dateOfBirth.value,
            sex: this.sex.value,
            language: this.language.value,
            languageLevel: this.languageLevel.value,
            country: this.country.value,
        };

        return this.userService.createUser(this.user);
    }

    get email(): FormControl {
        return this.registerForm.get('email') as FormControl;
    }

    get firstName(): FormControl {
        return this.registerForm.get('firstName') as FormControl;
    }

    get lastName(): FormControl {
        return this.registerForm.get('lastName') as FormControl;
    }

    get sex(): FormControl {
        return this.registerForm.get('sex') as FormControl;
    }

    get country(): FormControl {
        return this.registerForm.get('country') as FormControl;
    }

    get languageLevel(): FormControl {
        return this.registerForm.get('languageLevel') as FormControl;
    }

    get language(): FormControl {
        return this.registerForm.get('language') as FormControl;
    }

    get dateOfBirth(): FormControl {
        return this.registerForm.get('dateOfBirth') as FormControl;
    }

    get password(): FormControl {
        return this.registerForm.get('password') as FormControl;
    }

    get passwordConfirmation(): FormControl {
        return this.registerForm.get('passwordConfirmation') as FormControl;
    }
}
