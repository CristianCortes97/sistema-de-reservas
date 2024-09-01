import { bootstrapApplication } from '@angular/platform-browser';
import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';

const appConfig: ApplicationConfig = {
  providers: [importProvidersFrom(RouterModule.forRoot(routes))]
};

bootstrapApplication(AppComponent, appConfig)
  .catch(err => console.error(err));
