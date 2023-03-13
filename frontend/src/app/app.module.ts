import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from '@shared/shared.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ComponentsModule } from './modules/components/components.module';

@NgModule({
    declarations: [AppComponent],
    imports: [BrowserModule, SharedModule, AppRoutingModule, ComponentsModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
