import { Component, Inject, Injector, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AppComponentBase } from '../shared/app-component-base';
import { ReconciliationListDto } from './models/dtos/reconciliation-list-dto.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent extends AppComponentBase implements OnInit {

  public grid: ReconciliationListDto[];

  constructor(injector: Injector) {
    super(injector);

  }

  ngOnInit(): void {
    this.getYearlyTable();
  }


  getYearlyTable() {
    this.httpClient.get<ReconciliationListDto[]>(this.baseUrl + 'reconciliation/yearly-table')
      .subscribe(result => {
        this.grid = result;
      }, error => console.error(error));
  }
}
