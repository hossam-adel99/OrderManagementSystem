import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { routes } from './app/app.routes';
import { importProvidersFrom } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    importProvidersFrom(
      FormsModule,   // 👈 هذا يحل مشكلة ngModel
      CommonModule,  // 👈 هذا يحل مشاكل *ngFor و *ngIf
      RouterModule   // 👈 هذا يحل مشاكل routerLink
    )
  ]
});
