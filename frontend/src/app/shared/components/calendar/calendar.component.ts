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

    // constructor() { }

    onChange = (_: unknown) => {};

    onTouch = (_: unknown) => {};

    val = ''; // this is the updated value that the class accesses

    set value(val: Date) { // this value is updated by programmatic changes if( val !== undefined && this.val !== val){
        this._value = val;
        this.onChange(val);
        this.onTouch(val);
    }

    get value() {
        return this._value;
    }

    // this method sets the value programmatically
    writeValue(value: Date) {
        this._value = value;
    }

    // // upon UI element value changes, this method gets triggered
    registerOnChange(fn: (i: unknown) => void) {
        this.onChange = fn;
    }

    // upon touching the element, this method gets triggered
    registerOnTouched(fn: (i: unknown) => void) {
        this.onTouch = fn;
    }
}
