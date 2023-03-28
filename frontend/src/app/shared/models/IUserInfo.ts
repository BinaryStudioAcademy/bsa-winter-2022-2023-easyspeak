import { ITopic } from './ITopic';

export interface IUserInfo {
    firstName: string,
    lastName: string,
    email: string,
    country: string,
    language: string,
    sex: string,
    languageLevel: string
    topics?: ITopic[]
}
