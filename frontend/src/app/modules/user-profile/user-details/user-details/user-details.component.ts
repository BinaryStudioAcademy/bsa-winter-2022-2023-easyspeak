import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { BaseComponent } from '@core/base/base.component';
import { UserService } from '@core/services/user.service';
import { Ages } from '@shared/data/ages.util';
import { Countires } from '@shared/data/countries';
import { EnglishLevel } from '@shared/data/englishLevel';
import { Languages } from '@shared/data/languages';
import { Sex } from '@shared/data/sex';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ToastrService } from 'ngx-toastr';

import Utils from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit {
    public countries = Countires;

    ages = Ages;

    languages = Languages;

    emglishLevelEnumeration = EnglishLevel;

    englishLevelOptions: string[] = [];

    sexEnumeration = Sex;

    sexOptions: string[] = [];

    detailsForm;

    constructor(
        private fb: FormBuilder,
        private userService: UserService,
        private toastr: ToastrService,
    ) {
        super();
        this.detailsForm = Utils.detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.englishLevelOptions = Object.values(EnglishLevel) as string[];
    }

    ngOnInit(): void {
        this.userService.getUser()
            .pipe(this.untilThis)
            .subscribe(
                (resp) => this.detailsForm.patchValue({
                    firstName: resp[0].firstName,
                    lastName: resp[0].lastName,
                    email: resp[0].email,
                    country: resp[0].country,
                    sex: resp[0].sex,
                    language: resp[0].language,
                    englishLevel: resp[0].englishLevel,
                }),
            );
    }

    onSubmit() {
        this.userService.updateUser(this.detailsForm.value as IUserInfo)
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
