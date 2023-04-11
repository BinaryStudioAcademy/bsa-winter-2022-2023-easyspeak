import { IBaseTag } from '@shared/models/user/IBaseTag';

export interface UserFilter {
    topics: IBaseTag[] | null;
    langLevels: string[] | null;
    language: string | null;
    compatibility: number | null;
}
