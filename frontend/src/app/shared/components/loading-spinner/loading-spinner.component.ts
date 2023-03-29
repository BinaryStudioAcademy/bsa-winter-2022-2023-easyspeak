import { Component, Input } from '@angular/core';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-loading-spinner',
    templateUrl: './loading-spinner.component.html',
})
export class LoadingSpinnerComponent {
    // eslint-disable-next-line no-empty-function
    constructor(public spinnerService: SpinnerService) {}

    @Input() overlay: boolean;

    @Input() top = '40%';

    @Input() left = '49%';

    @Input() position = 'absolute';

    @Input() margin = '40px auto';

    @Input() zIndex = 99;
}
