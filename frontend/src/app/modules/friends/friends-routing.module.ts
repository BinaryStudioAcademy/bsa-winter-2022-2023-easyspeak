import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FriendsPageComponent } from '@modules/friends/friends-page/friends-page.component';

const routes: Routes = [{
    path: '',
    pathMatch: 'full',
    component: FriendsPageComponent,
},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class FriendsRoutingModule { }
