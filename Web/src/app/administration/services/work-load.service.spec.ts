import { TestBed } from '@angular/core/testing';

import { WorkLoadService } from './work-load.service';

describe('WorkLoadService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkLoadService = TestBed.get(WorkLoadService);
    expect(service).toBeTruthy();
  });
});
