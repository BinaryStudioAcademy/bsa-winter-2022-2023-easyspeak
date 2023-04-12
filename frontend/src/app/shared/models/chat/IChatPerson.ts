export interface IChatPerson {
    id?: number,
    email: string,
    firstName: string,
    lastName: string,
    isOnline: boolean,
    lastMessage: string,
    lastMessageDate: string,
    numberOfUnreadMessages: number,
    chatId: number,
    imageUrl: string
}
