import { INewTag } from '@shared/models/lesson/INewTag';

export interface IFilter {
    languageLevels: number[],
    tags: INewTag[],
    date: Date,
}
