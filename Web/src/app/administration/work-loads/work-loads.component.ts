import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { WorkLoadService } from '../services/work-load.service';
import { DebtComponent } from '../debt/debt.component';

@Component({
  selector: 'app-work-loads',
  templateUrl: './work-loads.component.html',
  styleUrls: ['./work-loads.component.scss']
})
export class WorkLoadsComponent implements OnInit {
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatPaginator) paginator2: MatPaginator;
  dataSource: MatTableDataSource<any>;
  dataSource2: MatTableDataSource<any>;

  public doctors: any[] = [];

  displayedColumns: string[] = ['name', 'rfc', 'type', 'createdAt', 'actions'];
  displayedColumns2: string[] = ['name', 'rfc', 'type', 'createdAt'];
  constructor(
    private _service: WorkLoadService,
    private _dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource([]);
    this.dataSource.paginator = this.paginator;
    this.dataSource2 = new MatTableDataSource([]);
    this.dataSource2.paginator = this.paginator2;
    this.getAll();
  }

  getAll(){
    this._service.getRegistros(1).subscribe((res: any) => {
      this.dataSource.data = res.workLoadRegistries.filter(x=>!x.complete);
      this.dataSource2.data = res.workLoadRegistries.filter(x=>x.complete);
    })
  }

  addDebt(item){
    this._dialog.open(DebtComponent, {
      width: '500px',
      data: item.contributorId
    }).afterClosed().subscribe(
      res => {
        this.getAll()
      }
    );
  }

}
