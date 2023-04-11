import { NotificationType } from '@shared/utils/user-notifications.util';

export interface INotification {
    id: number;
    firstName: string,
    lastName: string,
    text: string;
    type: NotificationType;
    isRead: boolean;
    link?: string;
    createdAt: Date;
    imagePath: string;
}
