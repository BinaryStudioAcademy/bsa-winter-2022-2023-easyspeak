import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.sass'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            // eslint-disable-next-line no-use-before-define
            useExisting: forwardRef(() => CalendarComponent),
            multi: true,
        },
    ],
})

export class CalendarComponent implements ControlValueAccessor {
    @Input() placeholder: string;

    maxDate = new Date();

    minDate = new Date(1900, 0, 1);

    _value: Date = new Date();

    // eslint-disable-next-line no-unused-vars,no-empty-function
    onChange = (_: unknown) => {};

    // eslint-disable-next-line no-unused-vars,no-empty-function
    onTouch = (_: unknown) => {};

    set value(val: Date) {
        this._value = val;
        const hours = new Date().getHours();

        val.setHours(hours);
        this.onChange(val.toISOString().split('T')[0]);
        this.onTouch(val);
    }

    get value() {
        return this._value;
    }

    writeValue(value: Date) {
        this._value = value;
    }

    registerOnChange(fn: (i: unknown) => void) {
        this.onChange = fn;
    }

    registerOnTouched(fn: (i: unknown) => void) {
        this.onTouch = fn;
    }
}
