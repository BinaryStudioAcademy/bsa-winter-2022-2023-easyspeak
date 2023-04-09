import { FormBuilder, Validators } from '@angular/forms';

export const detailsGroup = (fb: FormBuilder) => fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    birthDate: '',
    sex: '',
    country: '',
    language: '',
    languageLevel: '',
    email: '',
    imagePath: '',
    canOnlyFriendMessage: false,
});

export const userId = 0;
