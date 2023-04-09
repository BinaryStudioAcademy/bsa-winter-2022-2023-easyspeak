import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SocialPageComponent } from '@modules/social-page/social-page/social-page.component';

const routes: Routes = [
    { path: '', component: SocialPageComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SocialPageRoutingModule { }
