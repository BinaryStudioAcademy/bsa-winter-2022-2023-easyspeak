import { LanguageLevel } from '@shared/data/languageLevel';

export interface INewUser {
    firstName: string;
    lastName: string;
    email: string;
    birthDate: string;
    sex: string;
    languageLevel: LanguageLevel;
    country: string;
    language: string;
}
