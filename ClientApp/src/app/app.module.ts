import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SeedRequestsComponent } from './seed-requests/seed-requests.component';
import { SeedInventoryComponent } from './seed-inventory/seed-inventory.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SeedRequestsComponent,
    SeedInventoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: SeedInventoryComponent, pathMatch: 'full' },
      { path: 'seed-inventory', component: SeedInventoryComponent },
      { path: 'seed-requests', component: SeedRequestsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
