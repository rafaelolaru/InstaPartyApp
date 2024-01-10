import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MyPartiesPage } from './my-parties.page';

const routes: Routes = [
  {
    path: '',
    component: MyPartiesPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MyPartiesPageRoutingModule {}
