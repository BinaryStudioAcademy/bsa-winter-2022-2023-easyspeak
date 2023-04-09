import { NotificationType } from '@shared/utils/user-notifications.util';

export interface INewNotification {
    email: string,
    text: string,
    link?: string,
    type: NotificationType,
}
