import { NgModule } from '@angular/core';
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { AngularFireDatabaseModule } from '@angular/fire/compat/database';
import { AngularFirestoreModule } from '@angular/fire/compat/firestore';
import { AngularFireStorageModule } from '@angular/fire/compat/storage';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from '@core/core.module';
import { AuthService } from '@core/services/auth.service';
import { environment } from '@env/environment';
import { AuthModule } from '@modules/auth/auth.module';
import { SelectTopicsPageComponent } from '@modules/user-profile/select-topics-page/select-topics-page.component';
import { MaterialModule } from '@shared/material/material.module';
import { SharedModule } from '@shared/shared.module';
import { MarkdownModule } from 'ngx-markdown';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    declarations: [AppComponent, SelectTopicsPageComponent],
    imports: [
        BrowserModule,
        SharedModule,
        AppRoutingModule,
        ToastrModule.forRoot(),
        MarkdownModule.forRoot(),
        AngularFireModule.initializeApp(environment.firebaseConfig, 'EasySpeak'),
        AngularFireAuthModule,
        AngularFirestoreModule,
        AngularFireStorageModule,
        AngularFireDatabaseModule,
        AuthModule,
        BrowserAnimationsModule,
        CoreModule,
        MaterialModule,
    ],
    providers: [AuthService],
    bootstrap: [AppComponent],
})
export class AppModule {}
