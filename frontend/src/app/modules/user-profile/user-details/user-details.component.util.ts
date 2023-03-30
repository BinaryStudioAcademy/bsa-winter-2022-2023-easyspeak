import { FormBuilder } from '@angular/forms';

export const detailsGroup = (fb: FormBuilder) => fb.group({
    firstName: '',
    lastName: '',
    birthDate: '',
    sex: '',
    country: '',
    language: '',
    languageLevel: '',
    email: '',
    tags: '',
});

export const userId = 0;
