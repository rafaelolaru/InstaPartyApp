import { Component } from '@angular/core';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage {
  constructor(private navCtrl: NavController) {}

  subscribeToParty() {
    // Logic to subscribe to the party, add it to 'my-parties', etc.
    // This could involve API calls to handle the subscription process

    // Upon successful subscription, navigate to 'my-parties-page'
    this.navCtrl.navigateForward('/my-parties');
  }
}
