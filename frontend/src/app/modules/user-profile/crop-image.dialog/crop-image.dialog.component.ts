import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BaseComponent } from '@core/base/base.component';
import { AuthService } from '@core/services/auth.service';
import { base64ToFile, ImageCroppedEvent } from 'ngx-image-cropper';

import { UserDetailsComponent } from '../user-details/user-details/user-details.component';

import { HTMLInputEvent } from './HTMLInputElement';

@Component({
    selector: 'app-crop-image.dialog',
    templateUrl: './crop-image.dialog.component.html',
    styleUrls: ['./crop-image.dialog.component.sass'],
})
export class CropImageDialogComponent extends BaseComponent {
    @Input() imgChangeEvt: string;

    cropImgPreview: string = '';

    constructor(
        public dialogRef: MatDialogRef<UserDetailsComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { imgChangeEvt: HTMLInputEvent },
        private authService: AuthService,
        private http: HttpClient,
    ) {
        super();
    }

    cropImg(event: ImageCroppedEvent) {
        if (event.base64) {
            this.cropImgPreview = event.base64;
        }
    }

    onNoClick(): void {
        this.dialogRef.close();
    }

    saveAvatar() {
        if (this.data.imgChangeEvt && this.data.imgChangeEvt.target && this.data!.imgChangeEvt.target.files) {
            const fileWithNormName = new File(
                [base64ToFile(this.cropImgPreview)],
                this.data!.imgChangeEvt.target.files[0].name,
            );
            const file = new FormData();

            file.append(fileWithNormName.name, fileWithNormName);

            this.http.post(
                'http://localhost:5050/api/userprofile',
                file,
                { responseType: 'text' },
            ).subscribe(() => this.authService.loadUser().subscribe());
        }
    }
}
