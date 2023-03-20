import { NewSubquestion } from "./NewSubquestion";

export class NewQuestion {
    topic: string;
    subquestions: NewSubquestion[];

    constructor(topic: string, subquestions: NewSubquestion[]) {
        this.topic = topic;
        this.subquestions = subquestions;
    }
}
