import { Component, Inject, Input, LOCALE_ID } from '@angular/core';
import { IChatPerson } from '@shared/models/chat/IChatPerson';
import { IMessageGroup } from '@shared/models/chat/IMessageGroup';
import { IUserShort } from '@shared/models/IUserShort';
import { TimeUtils } from '@shared/utils/time.utils';
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

    @Input() currentPerson: IChatPerson;

    today = new Date();

    showDate: boolean;

    addTimeOffset = TimeUtils.addTimeOffset;

    getDateText(date: Date): string {
        if (moment(date).isSame(moment().startOf('day'))) {
            return 'Today';
        }
        if (moment(date).isSame(moment().add(-1, 'days').startOf('day'))) {
            return 'Yesterday';
        }

        return date.toLocaleDateString(this.locale, { day: 'numeric', month: 'short' });
    }
}
