import { Component, Inject, Input, LOCALE_ID } from '@angular/core';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import { IUserShort } from '@shared/models/IUserShort';
import * as moment from 'moment';

@Component({
    selector: 'app-message-group',
    templateUrl: './message-group.component.html',
    styleUrls: ['./message-group.component.sass'],
})
export class MessageGroupComponent {
    constructor(@Inject(LOCALE_ID) private locale: string) {
        this.showDate = true;
    }

    @Input() message: IMessageGroup;

    @Input() i: number;

    @Input() currentUser: IUserShort;

    today = new Date();

    showDate: boolean;

    getDateText(date: Date): string {
        if (moment(date).isSame(moment().startOf('day'))) {
            return 'Today';
        }
        if (moment(date).isSame(moment().add(-1, 'days').startOf('day'))) {
            return 'Yesterday';
        }

        return date.toLocaleDateString(this.locale, { day: 'numeric', month: 'short' });
    }

    addTimeOffset(date: string): string {
        const offset = new Date().getTimezoneOffset();
        const dateObject = new Date(date);

        dateObject.setMinutes(dateObject.getMinutes() - offset);

        return dateObject.toString();
    }
}
