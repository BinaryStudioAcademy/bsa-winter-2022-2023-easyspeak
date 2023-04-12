import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from '@core/base/base.component';
import { DataService } from '@core/services/data.service';
import { UserService } from '@core/services/user.service';
import { ITopic } from '@shared/models/ITopic';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-select-topics-page',
    templateUrl: './select-topics-page.component.html',
    styleUrls: ['./select-topics-page.component.sass'],
})
export class SelectTopicsPageComponent extends BaseComponent implements OnInit {
    topics: ITopic[] = [];

    selectedTopics: ITopic[] = [];

    constructor(
        private userService: UserService,
        private toastr: ToastrService,
        private router: Router,
        private dataService: DataService,
    ) {
        super();
    }

    ngOnInit(): void {
        this.dataService.getAllTags().subscribe((tags) => {
            this.topics = tags.map((tag): ITopic => ({
                name: tag.name,
                imgName: tag.imageUrl,
                selected: false,
            }));
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
