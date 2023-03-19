export interface IModal {
    header: string,
    cancelText?: string,
    confirmText?: string
    okText?: string
    /* eslint-disable  @typescript-eslint/no-explicit-any */
    component?: any
    hasButtons: boolean
}
