import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from '@core/base/base.component';
import { UserService } from '@core/services/user.service';
import { topics as data } from '@shared/data/topics';
import { ITopic } from '@shared/models/ITopic';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-select-topics-page',
    templateUrl: './select-topics-page.component.html',
    styleUrls: ['./select-topics-page.component.sass'],
})
export class SelectTopicsPageComponent extends BaseComponent {
    topics: ITopic[] = data;

    selectedTopics: ITopic[] = [];

    currentUser: IUserInfo;

    constructor(
        private userService: UserService,
        private toastr: ToastrService,
        private router: Router,
    ) {
        super();
        this.setCurrentUser();
    }

    setCurrentUser() {
        this.userService.getUser()
            .pipe(this.untilThis)
            .subscribe((resp) => {
                this.currentUser = resp;
            });
    }

    topicClick(topic: ITopic) {
        const updatedTopics = this.topics.map(t => (t.name === topic.name ? { ...t, selected: !t.selected } : t));

        this.selectedTopics = updatedTopics.filter(t => t.selected);
        this.topics = updatedTopics;
    }

    saveTopics() {
        this.userService.addTags(this.selectedTopics)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastr.success('Interests successfully added', 'Success!');
                this.router.navigate(['timetable']);
            });
    }
}
