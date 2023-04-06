import { Directive, ElementRef } from '@angular/core';

@Directive({
    selector: '[appScrollToBottom]',
})
export class ScrollToBottomDirective {
    constructor(private _el: ElementRef) { }

    public scrollToBottom() {
        const el: HTMLDivElement = this._el.nativeElement;

        el.scrollTop = Math.max(0, el.scrollHeight - el.offsetHeight);
    }
}
