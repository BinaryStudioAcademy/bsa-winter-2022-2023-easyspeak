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
        const updatedTopics = this.topics.map(t => (t.name === topic.name ? { ...t, selected: !t.selected } : t));

        this.selectedTopics = updatedTopics.filter(t => t.selected);
        this.topics = updatedTopics;
    }
}
