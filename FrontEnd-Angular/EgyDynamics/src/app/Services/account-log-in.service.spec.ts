import { TestBed } from '@angular/core/testing';

import { AccountLogInService } from './account-log-in.service';

describe('AccountLogInService', () => {
  let service: AccountLogInService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountLogInService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
