import { AfterViewInit, Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appTooltipWhenOverflow]'
})
export class TooltipWhenOverflowDirective implements AfterViewInit {
  domElement: any;

  constructor(private elementRef: ElementRef,
              private renderer: Renderer2) {
    this.domElement = this.elementRef.nativeElement;
  }

  ngAfterViewInit(): void {
    this.renderer.setProperty(this.domElement, 'scrollTop', 1);
    this.setToolTip();
  }
  
  @HostListener('window:resize', ['$event.target'])
    setToolTip() {
      (this.domElement.offsetHeight < this.domElement.scrollHeight ||
        this.domElement.offsetWidth < this.domElement.scrollWidth) ?
          this.renderer.setAttribute(this.domElement,
            'title',this.domElement.textContent) :
          this.renderer.removeAttribute(this.domElement, 'title');
    }

}
