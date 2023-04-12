import { INewTag } from '@shared/models/lesson/INewTag';

export interface UserFilter {
    topics: INewTag[] | null;
    langLevels: string[] | null;
    language: string | null;
    compatibility: number | null;
}
