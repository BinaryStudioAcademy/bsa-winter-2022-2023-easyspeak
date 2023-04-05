import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import * as moment from "moment";

export const MY_FORMATS = {
    parse: {
        dateInput: 'LL',
    },
    display: {
        dateInput: 'D MMMM YYYY',
        monthYearLabel: 'MMM YYYY',
        dateA11yLabel: 'LL',
        monthYearA11yLabel: 'MMMM YYYY',
    },
};

@Component({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.sass'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => this),
            multi: true,
        },
        {
            provide: DateAdapter,
            useClass: MomentDateAdapter,
            deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
        },
        {
            provide: MAT_DATE_FORMATS,
            useValue: MY_FORMATS,
        },
    ],
})
export class CalendarComponent implements ControlValueAccessor {
    maxDate = new Date();

    minDate = new Date(1900, 0, 1);

    @Input() placeholder: string;

    _value: moment.Moment;

    onChange?: (_: string) => void;

    onTouch?: (_: string) => void;

    set value(val: moment.Moment) {
        this._value = val;

        const date = val.toISOString().split('T')[0];

        this.onChange?.(date);
        this.onTouch?.(date);
    }

    get value() {
        return this._value;
    }

    writeValue(value: moment.Moment) {
        this._value = value;
    }

    registerOnChange(fn: (i: string) => void) {
        this.onChange = fn;
    }

    registerOnTouched(fn: (i: string) => void) {
        this.onTouch = fn;
    }
}
