import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MyPartiesPageRoutingModule } from './my-parties-routing.module';

import { MyPartiesPage } from './my-parties.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MyPartiesPageRoutingModule
  ],
  declarations: [MyPartiesPage]
})
export class MyPartiesPageModule {}
