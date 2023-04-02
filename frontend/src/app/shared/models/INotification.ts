export interface INotification {
    id: number;
    text: string;
    type: string;
    isRead: boolean;
    link?: string;
    createdAt: Date;
    imagePath: string;
}
