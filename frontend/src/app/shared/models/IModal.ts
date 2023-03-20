import { Type } from '@angular/core';

export interface IModal {
    header?: string,
    content?: string,
    cancelText?: string,
    confirmText?: string
    okText?: string
    /* eslint-disable  @typescript-eslint/no-explicit-any */
    component?: Type<any>
    hasButtons?: boolean
}
