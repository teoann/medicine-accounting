import { TestBed, async, inject } from '@angular/core/testing';

import { CheckAuthorizationGuard } from './check-authorization.guard';

describe('CheckAuthorizationGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CheckAuthorizationGuard]
    });
  });

  it('should ...', inject([CheckAuthorizationGuard], (guard: CheckAuthorizationGuard) => {
    expect(guard).toBeTruthy();
  }));
});
