import { INewTag } from '@shared/models/lesson/INewTag';

export interface UserFilter {
    tags: INewTag[] | null;
    langLevels: string[] | null;
    language: string[] | null;
    compatibility: number | null;
}
