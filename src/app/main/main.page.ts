// main.page.ts

import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { ApiService } from '../api.service';
import { DateFormatPipe } from '../date-format.pipe'; // Adjust the path based on your project structure

interface Party {
  id: number;
  name: string;
  date: string;
  description: string;
  formattedDate?: string; // Add this property for the formatted date
}

@Component({
  selector: 'app-main',
  templateUrl: './main.page.html',
  styleUrls: ['./main.page.scss'],
})
export class MainPage implements OnInit {
  parties: Party[] = [];

  constructor(private navCtrl: NavController, private apiService: ApiService, private dateFormatPipe: DateFormatPipe) {}

  ngOnInit() {
    this.getPartyData();
  }

  getPartyData() {
    this.apiService.getAllParties().subscribe(
      (response) => {
        // Assuming the API response is an array of parties
        this.parties = response.map((party: Party) => {
          return {
            ...party,
            formattedDate: this.dateFormatPipe.transform(party.date),
          };
        });
      },
      (error) => {
        console.error('Error fetching parties:', error);
        // Handle error, e.g., show an error message
      }
    );
  }

  goToPartyDetails(partyId: number) {
    this.navCtrl.navigateForward(`/details/${partyId}`);
  }
}
