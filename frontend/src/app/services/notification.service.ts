import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root',
})
export class NotificationService {
    constructor(private toastr: ToastrService) { }

    private toastrConfig = {
        closeButton: false,
        timeOut: 5000,
        extendedTimeOut: 1000,
        disableTimeOut: false,
        easing: 'ease-in',
        easeTime: 300,
        progressBar: true,
        positionClass: 'toast-top-right',
        tapToDismiss: true,
    };

    showSuccess(message: string, title: string) {
        this.toastr.success(message, title, this.toastrConfig);
    }

    showInfo(message: string, title: string) {
        this.toastr.info(message, title, this.toastrConfig);
    }

    showError(message: string, title: string) {
        this.toastr.error(message, title, this.toastrConfig);
    }
}
