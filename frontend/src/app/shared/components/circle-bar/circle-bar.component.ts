import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-circle-bar',
    templateUrl: './circle-bar.component.html',
    styleUrls: ['./circle-bar.component.sass'],
})
export class CircleBarComponent {
    @Input() progress?: number;
}
