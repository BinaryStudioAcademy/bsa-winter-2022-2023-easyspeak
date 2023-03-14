import { LanguageLevel } from '@shared/models/enums/LanguageLevel';
import { Sex } from '@shared/models/enums/Sex';

export interface IUser {
    uid: string;
    country: number;
    language: number;
    timezone: number;
    firstName: string;
    lastName: string;
    age: number;
    email: string;
    imagePath: string;
    sex: Sex;
    languageLevel: LanguageLevel;
    status: number;
    isSubscribed: boolean;
    isBanned: boolean;
}
