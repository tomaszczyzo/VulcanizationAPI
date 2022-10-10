import { TestBed } from '@angular/core/testing';

import { VulcanizationsService } from './vulcanizations.service';

describe('VulcanizationsService', () => {
  let service: VulcanizationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VulcanizationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
