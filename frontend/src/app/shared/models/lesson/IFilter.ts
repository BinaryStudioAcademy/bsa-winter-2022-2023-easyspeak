import { IIcon } from '@shared/models/IIcon';

export interface IFilter {
    languageLevels: number[],
    tags: IIcon[],
    date: Date,
}
