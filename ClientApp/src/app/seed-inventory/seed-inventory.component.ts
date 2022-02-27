import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-seed-inventory',
  templateUrl: './seed-inventory.component.html'
})
export class SeedInventoryComponent {
  public inventory: SeedRequestDto[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SeedRequestDto[]>(baseUrl + 'inventory/seeds').subscribe(result => {
      this.inventory = result;
    }, error => console.error(error));
  }
}

interface SeedRequestDto {
  seedId: number;
  seedName: string;
  requestedKernels: number;
  availableKernels: number;
  sufficientInventory: boolean;
}
