import { NotificationType } from '@shared/utils/user-notifications.util';

export interface INotification {
    id: number;
    text: string;
    type: NotificationType;
    isRead: boolean;
    link?: string;
    createdAt: Date;
    imagePath: string;
}
