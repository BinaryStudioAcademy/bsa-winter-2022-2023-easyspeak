import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '@shared/shared.module';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from '@core/core.module';

@NgModule({
    declarations: [AppComponent],
    imports: [BrowserModule, SharedModule, ToastrModule.forRoot(), AppRoutingModule, BrowserAnimationsModule, CoreModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
