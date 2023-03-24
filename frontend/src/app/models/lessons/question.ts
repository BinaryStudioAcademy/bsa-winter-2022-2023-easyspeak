import { Subquestion } from './subquestion';

export interface Question {
    id: number;
    topic: string;
    subQuestions: Subquestion[];
}
