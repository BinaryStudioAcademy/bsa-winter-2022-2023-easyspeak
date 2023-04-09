import {
    AbstractControl, ValidationErrors,
    ValidatorFn, Validators,
} from '@angular/forms';

export function lengthValidator(min: number, max: number): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        // const { value } = control;
        const l = control.value?.length;

        return ((l >= min) && (l <= max)) ?
            null : { lengthValidator: true };
    };
}
