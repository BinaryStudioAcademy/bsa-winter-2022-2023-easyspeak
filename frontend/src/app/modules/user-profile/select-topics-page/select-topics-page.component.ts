import { Component } from '@angular/core';
import { topics as data } from '@shared/data/topics';
import { ITopic } from '@shared/models/ITopic';

@Component({
    selector: 'app-select-topics-page',
    templateUrl: './select-topics-page.component.html',
    styleUrls: ['./select-topics-page.component.sass'],
})
export class SelectTopicsPageComponent {
    topics: ITopic[] = data;

    selectedTopics: ITopic[] = [];

    topicClick(topic: ITopic) {
        topic.selected = !topic.selected;
        if (topic.selected) {
            this.selectedTopics.push(topic);
        } else {
            delete this.selectedTopics[this.selectedTopics.findIndex(t => t.name === topic.name)];
            this.selectedTopics = this.selectedTopics.filter(topicToFilter => topicToFilter !== undefined);
        }
    }
}
