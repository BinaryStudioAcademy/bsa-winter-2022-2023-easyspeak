import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-stats-card',
    templateUrl: './stats-card.component.html',
    styleUrls: ['./stats-card.component.sass'],
})
export class StatsCardComponent {
    @Input() description: string;

    @Input() text: number | string;

    @Input() iconPath: string;
}
