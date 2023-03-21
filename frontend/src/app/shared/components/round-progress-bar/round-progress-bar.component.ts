import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-round-progress-bar',
    templateUrl: './round-progress-bar.component.html',
    styleUrls: ['./round-progress-bar.component.sass'],
})
export class RoundProgressBarComponent {
    @Input() status: number = 0;

    @Input() diameter: number = 20;
}
