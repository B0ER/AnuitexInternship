import { TestBed } from '@angular/core/testing';

import { PrintingEditionService } from './printing-edition.service';

describe('BookService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PrintingEditionService = TestBed.get(PrintingEditionService);
    expect(service).toBeTruthy();
  });
});
