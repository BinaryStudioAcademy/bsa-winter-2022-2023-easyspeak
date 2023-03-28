import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { BaseComponent } from '@core/base/base.component';
import { UserService } from '@core/services/user.service';
import { Ages } from '@shared/data/ages.util';
import { EnglishLevel } from '@shared/data/englishLevel';
import { Sex } from '@shared/data/sex';
import { IIcon } from '@shared/models/IIcon';
import { IUserInfo } from '@shared/models/IUserInfo';
import { getTags } from '@shared/utils/tagsForInterests';
import { ToastrService } from 'ngx-toastr';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { detailsGroup, userId } from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit {
    @Input() tagsList: IIcon[] = getTags();

    countries;

    ages: Date;

    languages;

    englishLevelEnumeration = EnglishLevel;

    englishLevelOptions: string[] = [];

    sexEnumeration = Sex;

    sexOptions: string[] = [];

    detailsForm;

    selectedTags: string[] = [];

    constructor(
        private fb: FormBuilder,
        private userService: UserService,
        private toastr: ToastrService,
        private countriesService: CountriesTzLangProviderService,
    ) {
        super();
        this.countries = this.countriesService.getCountriesList();
        this.languages = this.countriesService.getLanguagesList();
        this.detailsForm = detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.englishLevelOptions = Object.values(EnglishLevel) as string[];
        this.tagsList = getTags();
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
                    englishLevel: resp.languageLevel,
                    dateOfBirth: resp.birthDate,
                });

                this.userService.getTagNames().pipe(this.untilThis)
                    .subscribe(tags => this.selectedTags = tags);
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

    get englishLevel(): FormControl {
        return this.detailsForm.get('englishLevel') as FormControl;
    }

    get email(): FormControl {
        return this.detailsForm.get('email') as FormControl;
    }

    get interests(): FormControl {
        return this.detailsForm.get('instagram') as FormControl;
    }

    get facebook(): FormControl {
        return this.detailsForm.get('facebook') as FormControl;
    }

    get other(): FormControl {
        return this.detailsForm.get('other') as FormControl;
    }

    selectInterest($event: Event) {
        const ev = $event.target as HTMLInputElement;
        const numb = parseInt(ev.id, 10);

        if (ev.checked) {
            this.selectedTags = this.selectedTags.concat(this.tagsList[numb].icon_name);
        } else {
            this.selectedTags = this.selectedTags.filter(x => x !== this.tagsList[numb].icon_name);
        }
    }

    select(event: Date | null) {
        if (event) {
            const rrr = event;
        }
    }
}
