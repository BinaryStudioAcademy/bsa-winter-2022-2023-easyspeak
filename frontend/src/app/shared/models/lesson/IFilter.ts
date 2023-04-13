import { LanguageLevel } from '@shared/data/languageLevel';
import { INewTag } from '@shared/models/lesson/INewTag';

export interface IFilter {
    languageLevels: LanguageLevel[];
    tags: INewTag[];
    date: Date;
}
