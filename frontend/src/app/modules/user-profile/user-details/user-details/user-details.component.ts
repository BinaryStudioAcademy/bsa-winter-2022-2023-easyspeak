import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { BaseComponent } from '@core/base/base.component';
import { TagService } from '@core/services/tag.service';
import { UserService } from '@core/services/user.service';
import { LanguageLevel } from '@shared/data/languageLevel';
import { Sex } from '@shared/data/sex';
import { IIcon } from '@shared/models/IIcon';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ITag } from '@shared/models/user/ITag';
import { getTags } from '@shared/utils/tagsForInterests';
import { ToastrService } from 'ngx-toastr';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { detailsGroup } from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit {
    @Input() tagsList: IIcon[] = getTags();

    allTags: ITag[];

    allStringTags: string[];

    countries;

    languages;

    languageLevelOptions: string[] = [];

    sexEnumeration = Sex;

    sexOptions: string[] = [];

    detailsForm;

    selectedTags: ITag[] = [];

    constructor(
        private fb: FormBuilder,
        private userService: UserService,
        private toastr: ToastrService,
        private countriesService: CountriesTzLangProviderService,
        private tagService: TagService,
    ) {
        super();
        this.countries = this.countriesService.getCountriesList();
        this.languages = this.countriesService.getLanguagesList();
        this.detailsForm = detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.languageLevelOptions = Object.values(LanguageLevel) as string[];
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
                    languageLevel: resp.languageLevel,
                    birthDate: resp.birthDate,
                });

                this.userService.getTagNames().pipe(this.untilThis)
                    .subscribe(tags => this.selectedTags = tags);
            });

        this.tagService.getAllTags().pipe(this.untilThis).subscribe(
            tags => this.allTags = tags,
        );
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

    selectInterest($event: Event, i: number) {
        const ev = $event.target as HTMLInputElement;

        if (ev.checked) {
            this.selectedTags = this.selectedTags.concat({ name: this.tagsList[i].icon_name });
        } else {
            this.selectedTags = this.selectedTags.filter(x => x.name !== this.tagsList[i].icon_name);
        }

        // this.selectedTags=(ev.checked)
        //     ?this.selectedTags.concat({ name: this.tagsList[i].icon_name })
        //     :this.selectedTags.filter(x => x.name !== this.tagsList[i].icon_name);
    }

    getIconByName(name: string) {
        return this.tagsList.find(t => t.icon_name === name)?.link;
    }

    getStringTags() {
        return Array.from(this.allTags, t => t.name);
    }

    includesTags(item: string) {
        return this.selectedTags.find(t => t.name === item);
    }
}
