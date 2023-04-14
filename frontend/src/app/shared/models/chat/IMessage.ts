export interface IMessage {
    chatId: number;
    createdBy?: number;
    text: string;
    createdAt: Date;
    isRead: boolean;
}
