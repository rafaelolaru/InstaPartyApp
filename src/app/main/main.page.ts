import { Component } from '@angular/core';
import { Router } from '@angular/router'; // Import Router
import { Party } from '../party/party.model.js'; // Replace './party.model' with the correct path to your Party interface/model

@Component({
  selector: 'app-main',
  templateUrl: './main.page.html',
  styleUrls: ['./main.page.scss'],
})
export class MainPage {
  parties: Party[] = [];

  constructor(private router: Router) {
    // Initialize or fetch party data
    this.getPartyData();
  }

  goToPartyDetails(party: Party) {
    this.router.navigate(['/details', party.id]); // Navigate to details page with party ID
  }

  getPartyData() {
    // Simulated party data fetch
    // Replace this with actual API call to fetch party data
    // For demonstration, I'm using hardcoded data here

    // Assuming you receive an array of party objects from the API
    const partiesFromAPI: any[] = [
      { id: 1, name: 'Party Name 1', date: '2023-11-25' },
      { id: 2, name: 'Party Name 2', date: '2023-11-28' },
      // Add more party objects as needed
    ];

    // Map received data to Party interface and assign it to the 'parties' array
    this.parties = partiesFromAPI.map(party => ({
      id: party.id,
      name: party.name,
      date: party.date,
    }));
  }
}
