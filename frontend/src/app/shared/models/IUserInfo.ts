import { ITag } from '@shared/models/user/ITag';

import { ITopic } from './ITopic';

export interface IUserInfo {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    country: string,
    language: string,
    sex: string,
    languageLevel: string,
    birthDate: string,
    topics?: ITopic[],
    imagePath: string,
    canOnlyFriendMessage: boolean,
    tags: ITag[],
    isAdmin: boolean
}
