import { IMessage } from '@shared/models/chat/IMessage';

export interface IMessageGroup {
    date: Date;
    messages: IMessage[];
}
