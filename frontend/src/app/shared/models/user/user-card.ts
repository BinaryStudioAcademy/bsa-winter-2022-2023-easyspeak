import { FriendshipStatus } from '@shared/models/friendship/FriendDto';
export enum UserFriendshipStatus{
    Regular,
    Requester,
    Acceptor,
    Friend
}
export interface UserCard {
    name: string,
    email?: string,
    country?: string,
    language?: string,
    imagePath: string,
    languageLevel: string
    status: number | null;
    tags: string[]
    flag: string;
    userFriendshipStatus?: UserFriendshipStatus
}
