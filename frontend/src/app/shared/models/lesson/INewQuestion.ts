import { INewSubquestion } from './INewSubquestion';

export interface INewQuestion {
    topic: string;
    subquestions: INewSubquestion[];
}
