import { FormBuilder } from '@angular/forms';

export const detailsGroup = (fb: FormBuilder) => fb.group({
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    sex: '',
    country: '',
    language: '',
    languageLevel: '',
    email: '',
    instagram: '',
    facebook: '',
    other: '',
});

export const userId = 0;
