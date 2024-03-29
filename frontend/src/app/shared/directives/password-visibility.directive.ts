import { Directive, ElementRef } from '@angular/core';

@Directive({
    selector: '[appPasswordVisibility]',
})
export class PasswordVisibilityDirective {
    constructor(private el: ElementRef) {
        this.setup();
    }

    private isShown = false;

    toggle(span: HTMLElement) {
        this.isShown = !this.isShown;
        if (this.isShown) {
            this.el.nativeElement.setAttribute('type', 'text');
            span.innerHTML = '<img src="assets/password-visibility/opened-eye.svg" alt="opened-eye"/>';
        } else {
            this.el.nativeElement.setAttribute('type', 'password');
            span.innerHTML = '<img src="assets/password-visibility/closed-eye.svg" alt="closed-eye"/>';
        }
    }

    setup() {
        const parent = this.el.nativeElement.parentNode;
        const span = document.createElement('span');

        span.innerHTML = '<img src="assets/password-visibility/closed-eye.svg" alt="closed-eye"/>';
        span.style.position = 'absolute';
        span.style.right = '18px';
        span.style.top = '52%';
        span.style.height = '17px';
        span.style.transform = 'translateY(-50%)';
        span.style.zIndex = '10';
        span.style.cursor = 'pointer';
        span.addEventListener('click', () => {
            this.toggle(span);
        });
        parent.appendChild(span);
    }
}
