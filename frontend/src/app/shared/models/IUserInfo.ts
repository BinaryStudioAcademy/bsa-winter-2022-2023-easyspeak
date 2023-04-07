import { ITopic } from './ITopic';

export interface IUserInfo {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    country: string,
    language: string,
    sex: string,
    languageLevel: string
    topics?: ITopic[]
    imagePath: string;
    isAdmin: boolean;
}
