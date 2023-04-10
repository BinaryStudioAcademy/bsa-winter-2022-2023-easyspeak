import { ITag } from '@shared/models/user/ITag';

import { ITopic } from './ITopic';

export interface IUserInfo {
    firstName: string;
    lastName: string;
    email: string;
    country: string;
    language: string;
    sex: string;
    languageLevel: string;
    birthDate: Date;
    topics?: ITopic[]
    imagePath: string;
    canOnlyFriendMessage: boolean;
    tags: ITag[];
    isAdmin: boolean;
}
