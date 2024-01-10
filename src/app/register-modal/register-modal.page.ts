import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-register-modal',
  templateUrl: './register-modal.page.html',
})
export class RegisterModalPage {
  username: string = '';
  password: string = '';
  age: number | null = null;
  email: string = '';
  city: string = '';
  phoneNumber: string = '';
  errorMessage: string = '';

  constructor(private modalController: ModalController, private apiService: ApiService) {}

  register() {
    if (
      this.username.trim() &&
      this.password.trim() &&
      this.age !== null &&
      this.age >= 0 &&
      this.email.trim() &&
      this.city.trim() &&
      this.phoneNumber.trim()
    ) {
      const registrationData = {
        username: this.username,
        password: this.password,
        age: this.age,
        email: this.email,
        city: this.city,
        phoneNumber: this.phoneNumber,
      };

      this.apiService.register(registrationData).subscribe(
        (response) => {
          console.log('Registration successful:', response);
          this.dismissModal();
        },
        (error) => {
          console.error('Registration failed:', error);
          // Optionally, set an error message for failed registration
          this.errorMessage = 'Registration failed. Please try again.';
        }
      );
    } else {
      this.errorMessage = 'Please fill in all fields correctly.';
    }
  }

  dismissModal() {
    this.modalController.dismiss();
  }
}
