import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-modal',
  templateUrl: './register-modal.page.html',
  styleUrls: ['./register-modal.page.scss'],
})
export class RegisterModalPage {
  [x: string]: any;
  username: string = '';
  password: string = '';
  age: number | null = null;
  email: string = '';
  city: string = '';
  phoneNumber: string = '';
  errorMessage: string = '';

  constructor(private modalController: ModalController, private apiService: ApiService, private router: Router) {}

  register() {
    if (
      this.username.trim() &&
      this.password.trim() &&
      this.age !== null &&
      this.age >= 0 &&
      this.email.trim() &&
      this.city.trim() &&
      this.phoneNumber.trim() &&
      this.isPhoneNumberValid() &&
      this.isEmailValid()
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
          this.navigateToMainPage();
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

  isPhoneNumberValid(): boolean {
    // Regular expression to match 10-digit phone number
    const phoneNumberPattern = /^\d{10}$/;
    return phoneNumberPattern.test(this.phoneNumber);
  }

  isEmailValid(): boolean {
    // Regular expression to match a basic email format
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(this.email);
  }
  private navigateToMainPage() {
    this.modalController.dismiss(); // Dismiss the modal first
    // Use Router to navigate to the main page
    this['router'].navigate(['/main']);
  }
}

