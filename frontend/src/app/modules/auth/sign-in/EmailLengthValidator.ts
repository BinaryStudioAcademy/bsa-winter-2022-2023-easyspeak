import { Validators } from '@angular/forms';

export class EmailLengthValidator {
    public readonly emailLength = [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(3),
    ];
}
