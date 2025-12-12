import { TestBed } from '@angular/core/testing';

import { ApiAmadeusService } from './api-amadeus-service';

describe('ApiAmadeusService', () => {
  let service: ApiAmadeusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiAmadeusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
