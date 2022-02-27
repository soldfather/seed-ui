import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-seed-requests',
  templateUrl: './seed-requests.component.html'
})
export class SeedRequestsComponent {
  public requests: SeedRequestDto[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SeedRequestDto[]>(baseUrl + 'inventory/requests').subscribe(result => {
      this.requests = result;
    }, error => console.error(error));
  }

}

interface SeedRequestDto {
  requestId: number;
  seedId: number;
  seedName: string;
  requestedKernels: number;
  availableKernels: number;
  sufficientInventory: boolean;
}
