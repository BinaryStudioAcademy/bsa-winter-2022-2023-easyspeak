import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseComponent } from '@core/base/base.component';
import { AuthService } from '@core/services/auth.service';
import { DataService } from '@core/services/data.service';
import { UserService } from '@core/services/user.service';
import { NgSelectComponent } from '@ng-select/ng-select';
import { Ages } from '@shared/data/ages.util';
import { LanguageLevel } from '@shared/data/languageLevel';
import { emailFormatRegex, nameFormatRegex, passFormatRegex } from '@shared/data/regex.util';
import { Sex } from '@shared/data/sex';
import { INewUser } from '@shared/models/INewUser';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { validationErrorMessage } from './error-helper';
import { matchpassword } from './matchpassword.validator';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.sass'],
})
export class SignUpComponent extends BaseComponent implements OnInit {
    languageLevelEnumeration = LanguageLevel;

    sexEnumeration = Sex;

    languageLevels: string[];

    ages: string[];

    countries: string[];

    sexOptions: string[];

    languages: string[];

    placeholder = 'sex';

    @ViewChild('ageDropdown') ageDropdown: NgSelectComponent;

    @ViewChild('sexDropdown') sexDropdown: NgSelectComponent;

    @ViewChild('countryDropdown') countryDropdown: NgSelectComponent;

    @ViewChild('languageDropdown') languageDropdown: NgSelectComponent;

    @ViewChild('levelDropdown') levelDropdown: NgSelectComponent;

    registerForm = new FormGroup({
        email: new FormControl('', {
            validators: [Validators.required, Validators.maxLength(50), Validators.pattern(emailFormatRegex)],
            updateOn: 'submit',
        }),
        firstName: new FormControl('', {
            validators: [Validators.required, Validators.pattern(nameFormatRegex)],
            updateOn: 'submit',
        }),
        lastName: new FormControl('', {
            validators: [Validators.required, Validators.pattern(nameFormatRegex)],
            updateOn: 'submit',
        }),
        password: new FormControl('', {
            validators: [Validators.required, Validators.pattern(passFormatRegex)],
            updateOn: 'submit',
        }),
        passwordConfirmation: new FormControl('', {
            validators: [Validators.required],
            updateOn: 'submit',
        }),
        sex: new FormControl('', {
            validators: [Validators.required],
        }),
        languageLevel: new FormControl('', [Validators.required]),
        country: new FormControl('', [Validators.required]),
        language: new FormControl('', [Validators.required]),
        dateOfBirth: new FormControl('', [Validators.required]),

    }, {
        validators: matchpassword,
    });

    user: INewUser;

    inputMap = new Map<string, boolean>([
        ['firstName', false],
        ['lastName', false],
        ['password', false],
        ['passwordConfirmation', false],
        ['sex', false],
        ['country', false],
        ['language', false],
        ['languageLevel', false],
        ['email', false],
    ]);

    constructor(
        private formBuilder: FormBuilder,
        private countriesTzLangProvider: CountriesTzLangProviderService,
        private authService: AuthService,
        private toastr: ToastrService,
        private userService: UserService,
        private router: Router,
        private dataService: DataService,
    ) {
        super();
    }

    ngOnInit(): void {
        this.setUpData();
    }

    submitForm() {
        if (this.validateForm()) {
            this.signUp();
        }
    }

    private setUpData() {
        this.countries = this.countriesTzLangProvider.getCountriesList().map((x) => x.name);
        this.dataService.getAllLanguages().subscribe((languages) => {
            this.languages = languages;
        });
        this.languageLevels = Object.values(LanguageLevel) as string[];
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.ages = Ages;
    }

    private signUp() {
        if (this.registerForm.valid) {
            this.authService
                .signUp(this.email.value, this.password.value)
                .pipe(switchMap(() => this.createUser().pipe(this.untilThis)))
                .subscribe((user) => {
                    const userShort = {
                        email: user.email,
                        firstName: user.firstName,
                        lastName: user.lastName,
                        imagePath: '',
                        isAdmin: false,
                    };

                    this.authService.setUser(userShort);
                    this.toastr.success('Account successfully created', 'Success!');
                    this.router.navigate(['topics']);
                }, error => {
                    const errorMessage: string | undefined = this.getFireBaseMessage(error.code);

                    this.toastr.error(errorMessage, 'Sign up');
                });
        }
    }

    private validateForm() {
        [...this.inputMap.keys()].forEach((key) => {
            this.inputMap.set(key, true);
        });

        return this.registerForm.valid;
    }

    private createUser() {
        this.user = {
            firstName: this.firstName.value,
            lastName: this.lastName.value,
            email: this.email.value,
            birthDate: this.dateOfBirth.value,
            sex: this.sex.value,
            language: this.language.value,
            languageLevel: this.languageLevel.value,
            country: this.country.value,
        };

        return this.userService.createUser(this.user);
    }

    getErrorMessage(control: FormControl): string {
        const errorEntry = Object.entries(validationErrorMessage)
            .find(([key]) => control.hasError(key));

        if (errorEntry) {
            return errorEntry[1];
        }

        return '';
    }

    getFormErrorMessage(formGroup: FormGroup): string {
        const errorEntry = Object.entries(validationErrorMessage)
            .find(([key]) => formGroup.hasError(key));

        if (errorEntry) {
            return errorEntry[1];
        }

        return '';
    }

    ClearErrors(controlName: string) {
        this.inputMap.set(controlName, false);
        this.registerForm.setErrors(null);
    }

    GetErrorMessageByKey(id: string) {
        return Object.entries(validationErrorMessage).find(([t]) => t === id)?.[1];
    }

    getFireBaseMessage(code: string) {
        switch (code) {
            case 'auth/email-already-in-use':
                return this.GetErrorMessageByKey('alreadyRegistered');
            default: return undefined;
        }
    }

    CheckCondition(controlName: string, condition: string) {
        const isChanged = this.inputMap.get(controlName) ?? false;
        const control = this.registerForm.get(controlName) as FormControl;

        switch (condition) {
            case 'required':
                return ((control.errors?.[condition] && control.touched)
                    || control.pristine) && isChanged;
            case 'pattern':
                return control.errors?.[condition] && isChanged;
            case 'matchError':
                if (control?.parent?.errors?.[condition] && !control.errors?.['required']) {
                    control.setErrors({ matchError: true });

                    return this.registerForm.errors?.[condition] && isChanged;
                }

                return false;
            default: return undefined;
        }
    }

    expandSexDropdown = () => this.sexDropdown.open();

    expandCountryDropdown = () => this.countryDropdown.open();

    expandLanguageDropdown = () => this.languageDropdown.open();

    expandLevelDropdown = () => this.levelDropdown.open();

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
