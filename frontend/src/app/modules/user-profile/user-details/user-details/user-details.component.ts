import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { BaseComponent } from '@core/base/base.component';
import { DataService } from '@core/services/data.service';
import { UserService } from '@core/services/user.service';
import { Ages } from '@shared/data/ages.util';
import { EnglishLevel } from '@shared/data/englishLevel';
import { Sex } from '@shared/data/sex';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ToastrService } from 'ngx-toastr';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { detailsGroup, userId } from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit {
    countries;

    ages = Ages;

    languages: string[];

    languageLevelOptions: string[] = [];

    sexEnumeration = Sex;

    sexOptions: string[] = [];

    detailsForm;

    userFirstName: string;

    userLastName: string;

    imagePath: string;

    constructor(
        private fb: FormBuilder,
        private userService: UserService,
        private toastr: ToastrService,
        private countriesService: CountriesTzLangProviderService,
        private constantsService: DataService,
    ) {
        super();
        this.countries = this.countriesService.getCountriesList();
        this.constantsService.getAllLanguages().subscribe((languages) => {
            this.languages = languages;
        });
        this.detailsForm = detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.languageLevelOptions = Object.values(EnglishLevel) as string[];
    }

    ngOnInit(): void {
        this.userService
            .getUser()
            .pipe(this.untilThis)
            .subscribe((resp) => {
                this.detailsForm.patchValue({
                    firstName: resp.firstName,
                    lastName: resp.lastName,
                    email: resp.email,
                    country: resp.country,
                    sex: resp.sex,
                    language: resp.language,
                    languageLevel: resp.languageLevel,
                });
                this.userFirstName = resp.firstName;
                this.userLastName = resp.lastName;
                this.imagePath = resp.imagePath;
            });
    }

    onSubmit() {
        this.userService
            .updateUser(userId, this.detailsForm.value as IUserInfo)
            .pipe(this.untilThis)
            .subscribe(() => this.toastr.success('User info updated successfully.', 'Success!'));
    }

    get firstName(): FormControl {
        return this.detailsForm.get('firstName') as FormControl;
    }

    get lastName(): FormControl {
        return this.detailsForm.get('lastName') as FormControl;
    }

    get dateOfBirth(): FormControl {
        return this.detailsForm.get('dateOfBirth') as FormControl;
    }

    get sex(): FormControl {
        return this.detailsForm.get('sex') as FormControl;
    }

    get country(): FormControl<string> {
        return this.detailsForm.get('country') as FormControl<string>;
    }

    get language(): FormControl {
        return this.detailsForm.get('language') as FormControl;
    }

    get languageLevel(): FormControl {
        return this.detailsForm.get('languageLevel') as FormControl;
    }

    get email(): FormControl {
        return this.detailsForm.get('email') as FormControl;
    }

    get instagram(): FormControl {
        return this.detailsForm.get('instagram') as FormControl;
    }

    get facebook(): FormControl {
        return this.detailsForm.get('facebook') as FormControl;
    }

    get other(): FormControl {
        return this.detailsForm.get('other') as FormControl;
    }
}
