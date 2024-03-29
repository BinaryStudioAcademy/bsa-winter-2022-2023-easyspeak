import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { BaseComponent } from '@core/base/base.component';
import { AuthService } from '@core/services/auth.service';
import { DataService } from '@core/services/data.service';
import { UserService } from '@core/services/user.service';
import { environment } from '@env/environment';
import { CropImageDialogComponent } from '@modules/user-profile/crop-image.dialog/crop-image.dialog.component';
import { LanguageLevel } from '@shared/data/languageLevel';
import { mapLanguageLevelToString, mapStringToLanguageLevel } from '@shared/data/LanguageLevelMapper';
import { Sex } from '@shared/data/sex';
import { IIcon } from '@shared/models/IIcon';
import { IUserInfo } from '@shared/models/IUserInfo';
import { IUserShort } from '@shared/models/IUserShort';
import { IBaseTag } from '@shared/models/user/IBaseTag';
import { ITag } from '@shared/models/user/ITag';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs';

import { CountriesTzLangProviderService } from 'src/app/services/countries-tz-lang-provider.service';

import { detailsGroup } from '../user-details.component.util';

@Component({
    selector: 'app-user-details',
    templateUrl: './user-details.component.html',
    styleUrls: ['./user-details.component.sass'],
})
export class UserDetailsComponent extends BaseComponent implements OnInit, AfterViewInit {
    @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

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
        public cropImgDialog: MatDialog,
        public authService: AuthService,
        private http: HttpClient,
        private dataService: DataService,
    ) {
        super();
        this.countries = this.countriesService.getCountriesList();
        this.dataService.getAllLanguages().subscribe((languages) => {
            this.languages = languages;
        });
        this.dataService.getAllTags().subscribe((tags) => {
            this.tagsList = tags.map((tag): IIcon => ({
                ...tag,
                link: `assets/topic-icons/${tag.imageUrl}`,
            }));

            this.allTags = tags.map((item) => ({
                name: item.name,
                id: item.id,
                isSelected: false,
            }));
        });

        this.detailsForm = detailsGroup(this.fb);
        this.sexOptions = Object.values(this.sexEnumeration) as string[];
        this.languageLevelOptions = Object.values(LanguageLevel).map(level => mapLanguageLevelToString(level));
    }

    ngOnInit(): void {
        this.userService
            .getUser()
            .pipe(this.untilThis)
            .subscribe((resp) => {
                this.detailsForm.patchValue({ ...resp });

                this.languageLevel.setValue(mapLanguageLevelToString(resp.languageLevel));
                this.userFirstName = resp.firstName;
                this.userLastName = resp.lastName;
                this.imagePath = resp.imagePath;
            });

        this.userService.getUserTags().pipe(this.untilThis)
            .subscribe(tags => {
                this.selectedTags = tags.filter(t => t.isSelected);
            });
        this.authService.user.subscribe((user) => this.setImgPath(user));
    }

    ngAfterViewInit() {
        this.fileInput.nativeElement.onclick = () => {
            this.fileInput.nativeElement.value = null;
        };
    }

    onSubmit() {
        const userDetails = <IUserInfo> this.detailsForm.value;

        userDetails.languageLevel = mapStringToLanguageLevel(this.languageLevel.value);

        userDetails.tags = this.selectedTags;

        this.userService
            .updateUser(userDetails)
            .pipe(this.untilThis)
            .subscribe(() => this.toastr.success('User info updated successfully.', 'Success!'));
    }

    onFileChange(imgChangeEvt: Event) {
        if (imgChangeEvt) {
            this.cropImgDialog.open(CropImageDialogComponent, {
                data: {
                    imgChangeEvt,
                },
            });
        }
    }

    setEmojiAvatar(emojiName: string) {
        this.http.post(
            `${environment.coreUrl}/api/userprofile/setemoji/${emojiName}`,
            emojiName,
            { responseType: 'text' },
        ).pipe(switchMap(async () => this.authService.loadUser().subscribe()))
            .subscribe();
    }

    private setImgPath(user: IUserShort) {
        this.imagePath = user.imagePath;
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
