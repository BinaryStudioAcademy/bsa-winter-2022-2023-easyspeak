import { FormBuilder, FormControl, Validators } from '@angular/forms';
import * as moment from 'moment';

export const detailsGroup = (fb: FormBuilder) => fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    birthDate: new FormControl(new Date(), Validators.required),
    sex: '',
    country: '',
    language: '',
    languageLevel: '',
    email: '',
    imagePath: '',
    canOnlyFriendMessage: false,
});

export const userId = 0;
