import { Component } from '@angular/core';

@Component({
    selector: 'app-write-email',
    templateUrl: './write-email.component.html',
    styleUrls: ['./write-email.component.sass'],
})
export class WriteEmailComponent {
    emailPattern: RegExp = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    email: string = '';

    isMatch: boolean = true;

    checkMail(): void {
        this.isMatch = this.emailPattern.test(this.email);
    }

    changedMail(): void {
        this.isMatch = true;
    }
}
