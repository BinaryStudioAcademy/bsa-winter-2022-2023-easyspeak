import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const matchpassword: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    const newPassword = control.get('newPassword');
    const repeatPassword = control.get('repeatPassword');

    if (newPassword && repeatPassword && newPassword?.value !== repeatPassword?.value) {
        return {
            matchError: true,
        };
    }

    return null;
};
