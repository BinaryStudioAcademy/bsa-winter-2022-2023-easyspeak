import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from '@shared/shared.module';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    declarations: [AppComponent],
    imports: [BrowserModule, SharedModule, ToastrModule.forRoot(), AppRoutingModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
