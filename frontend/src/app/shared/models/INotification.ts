export interface INotification {
    id: number;
    text: string;
    email?: string;
    type: number;
    isRead: boolean;
}
