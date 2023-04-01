import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.sass'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
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

    onChange?: (_: string) => void;

    onTouch?: (_: string) => void;

    set value(val: Date) {
        this._value = val;
        const hours = new Date().getHours();

        val.setHours(hours);
        const date = val.toISOString().split('T')[0];

        this.onChange?.(date);
        this.onTouch?.(date);
    }

    get value() {
        return this._value;
    }

    writeValue(value: Date) {
        this._value = value;
    }

    registerOnChange(fn: (i: string) => void) {
        this.onChange = fn;
    }

    registerOnTouched(fn: (i: string) => void) {
        this.onTouch = fn;
    }
}
