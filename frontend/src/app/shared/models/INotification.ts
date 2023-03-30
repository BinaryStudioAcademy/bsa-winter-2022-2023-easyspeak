export interface INotification {
    id: number;
    text: string;
    email?: string;
    type: string;
    isRead: boolean;
    link?: string
}
