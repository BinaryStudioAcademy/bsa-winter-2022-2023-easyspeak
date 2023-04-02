import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const matchpassword: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password');
    const confirmation = control.get('passwordConfirmation');

    if (password && confirmation && password?.value !== confirmation?.value) {
        return {
            matchError: true,
        };
    }

    return null;
};
