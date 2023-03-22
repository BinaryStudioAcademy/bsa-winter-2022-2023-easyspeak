import { INewTag } from "./INewTag";

export interface IFilter {
    languageLevels: number[],
    tags: INewTag[],
    date: Date,
}
