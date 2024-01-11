// import { Injectable } from '@angular/core';
// import { Router, NavigationEnd } from '@angular/router';
// import { filter } from 'rxjs/operators';

// @Injectable({
//   providedIn: 'root'
// })
// export class RouteStateService {
//   constructor(private router: Router) {
//     this.init();
//   }

//   init() {
//     this.router.events
//       .pipe(filter(event => event instanceof NavigationEnd))
//       .subscribe((event: NavigationEnd) => {
//         // Save the current route to local storage
//         localStorage.setItem('lastRoute', event.urlAfterRedirects);
//       });
//   }

//   getLastRoute(): string {
//     // Retrieve the last route from local storage
//     return localStorage.getItem('lastRoute');
//   }
// }
