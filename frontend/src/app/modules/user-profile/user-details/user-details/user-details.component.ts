import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { BaseComponent } from '@core/base/base.component';
import { DataService } from '@core/services/data.service';
import { UserService } from '@core/services/user.service';
import { LanguageLevel } from '@shared/data/languageLevel';
import { Sex } from '@shared/data/sex';
import { IIcon } from '@shared/models/IIcon';
import { IUserInfo } from '@shared/models/IUserInfo';
import { IBaseTag } from '@shared/models/user/IBaseTag';
import { ITag } from '@shared/models/user/ITag';
import { ToastrService } from 'ngx-toastr';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { detailsGroup } from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit {
    tagsList: IIcon[];

    allTags: ITag[];

    countries;

    languages: string[];

    languageLevelOptions: string[] = [];

    sexEnumeration = Sex;

    sexOptions: string[] = [];

    detailsForm;

    selectedTags: ITag[] = [];

    userFirstName: string;

    userLastName: string;

    imagePath: string;

    constructor(
        private fb: FormBuilder,
        private userService: UserService,
        private toastr: ToastrService,
        private countriesService: CountriesTzLangProviderService,
        private dataService: DataService,
    ) {
        super();
        this.countries = this.countriesService.getCountriesList();
        this.dataService.getAllLanguages().subscribe((languages) => {
            this.languages = languages;
        });
        this.dataService.getAllTags().subscribe((tags) => {
            this.tagsList = tags.map((tag): IIcon => ({
                id: tag.id,
                name: tag.name,
                link: `assets/topic-icons/${tag.imageUrl}`,
            }));
        });
        this.detailsForm = detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.languageLevelOptions = Object.values(LanguageLevel) as string[];
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
                    birthDate: resp.birthDate });

                this.userService.getUserTags().pipe(this.untilThis)
                    .subscribe(tags => {
                        this.allTags = tags;
                        this.selectedTags = tags.filter(t => t.isSelected);
                    });
                this.userFirstName = resp.firstName;
                this.userLastName = resp.lastName;
                this.imagePath = resp.imagePath;
            });
    }

    onSubmit() {
        const userDetails = <IUserInfo> this.detailsForm.value;

        userDetails.tags = this.selectedTags;

        this.userService
            .updateUser(userDetails)
            .pipe(this.untilThis)
            .subscribe(() => this.toastr.success('User info updated successfully.', 'Success!'));
    }

    get firstName(): FormControl {
        return this.detailsForm.get('firstName') as FormControl;
    }

    get lastName(): FormControl {
        return this.detailsForm.get('lastName') as FormControl;
    }

    get birthDate(): FormControl {
        return this.detailsForm.get('birthDate') as FormControl;
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

    selectInterest(tag: ITag) {
        this.selectedTags = this.includesTags(tag.id)
            ? this.selectedTags.filter(x => x.id !== tag.id)
            : [...this.selectedTags, tag];
    }

    findTag<T extends IBaseTag>(collection: T[], id: number) {
        return collection.find(t => t.id === id);
    }

    getIconById(id: number) {
        return (this.findTag<IIcon>(this.tagsList, id))?.link;
    }

    includesTags(id: number) {
        return this.findTag<ITag>(this.selectedTags, id);
    }
}
