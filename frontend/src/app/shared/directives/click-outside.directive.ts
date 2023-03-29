import { DOCUMENT } from '@angular/common';
import { AfterViewInit, Directive, ElementRef, EventEmitter, Inject, OnDestroy, Output } from '@angular/core';
import { filter, fromEvent, Subscription } from 'rxjs';

@Directive({
    selector: '[appClickOutside]',
})
export class ClickOutsideDirective implements AfterViewInit, OnDestroy {
    @Output() appClickOutside = new EventEmitter<void>();

    documentClickSubscription: Subscription | undefined;

    constructor(
        private element: ElementRef,
        @Inject(DOCUMENT) private document: Document,
    ) {}

    ngAfterViewInit(): void {
        this.documentClickSubscription = fromEvent(this.document, 'click')
            .pipe(
                filter((event) => !this.isInside(event.target as HTMLElement)),
            )
            .subscribe(() => {
                this.appClickOutside.emit();
            });
    }

    ngOnDestroy(): void {
        this.documentClickSubscription?.unsubscribe();
    }

    isInside(elementToCheck: HTMLElement): boolean {
        return (
            elementToCheck === this.element.nativeElement ||
        this.element.nativeElement.contains(elementToCheck)
        );
    }
}
