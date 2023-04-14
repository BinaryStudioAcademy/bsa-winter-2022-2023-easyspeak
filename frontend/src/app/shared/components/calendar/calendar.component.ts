import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import * as moment from 'moment';

export const MY_FORMATS = {
    parse: {
        dateInput: 'DD.MM.YYYY',
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

    dateRegex = new RegExp('^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$');

    onChange?: (_: string) => void;

    onTouch?: (_: string) => void;

    set value(val: moment.Moment) {
        console.log(val.format('DD.MM.YYYY'));
        console.log(this.dateRegex.test(val.format('DD.MM.YYYY')));
        //if( true) {
        if(this.dateRegex.test(val.format('DD.MM.YYYY'))) {
            console.log('if');
            this._value = moment(val.format('MM-DD-YYYY'));

            const date = val.format('MM-DD-YYYY');

            this.onChange?.(date);
            this.onTouch?.(date);
        }
        else{
            console.log('else');
        }
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
