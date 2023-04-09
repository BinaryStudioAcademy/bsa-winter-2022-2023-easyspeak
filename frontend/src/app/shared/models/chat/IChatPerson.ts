export interface IChatPerson {
    firstName: string
    lastName: string,
    isOnline: boolean,
    lastMessage: string,
    lastMessageDate: string,
    numberOfUnreadMessages: number,
    chatId: number
}
