import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { ModalController } from '@ionic/angular';
import { RegisterModalPage } from '../register-modal/register-modal.page';



@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage {
  username: string = '';
  password: string = '';
  loginError: string = '';

  constructor(private apiService: ApiService, private router: Router, private modalController: ModalController) {}

  async openRegisterModal() {
    const modal = await this.modalController.create({
      component: RegisterModalPage,
      componentProps: {} // Optional: Pass data to the modal
    });
    return await modal.present();
  }
  login() {
    if (this.username && this.password) {
      this.apiService.login(this.username, this.password).subscribe(
        (response) => {
          if (response && response.token) {
            console.log('Login successful');
            this.router.navigate(['/main']); // Redirect to the main page upon successful login
          } else {
            this.loginError = 'Invalid username or password';
          }
        },
        (error) => {
          console.error('Error during login:', error);
          this.loginError = 'An error occurred. Please try again later.';
        }
      );
    } else {
      this.loginError = 'Please enter username and password.';
    }
  }
}
