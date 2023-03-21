import { FormBuilder } from '@angular/forms';

export default class Utils {
    static detailsGroup(fb: FormBuilder) {
        return fb.group({
            firstName: '',
            lastName: '',
            dateOfBirth: '',
            sex: '',
            country: '',
            language: '',
            englishLevel: '',
            email: '',
            instagram: '',
            facebook: '',
            other: '',
        });
    }
}
