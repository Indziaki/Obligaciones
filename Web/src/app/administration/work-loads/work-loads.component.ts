import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { WorkLoadService } from '../services/work-load.service';

@Component({
  selector: 'app-work-loads',
  templateUrl: './work-loads.component.html',
  styleUrls: ['./work-loads.component.scss']
})
export class WorkLoadsComponent implements OnInit {
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: MatTableDataSource<any>;

  public doctors: any[] = [];

  displayedColumns: string[] = ['name', 'rfc', 'type', 'createdAt', 'complete', 'actions'];
  constructor(
    private _service: WorkLoadService,
    private _dialog: MatDialog,
    ) { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource([]);
    this.dataSource.paginator = this.paginator;
    this.getAll();
  }

  getAll(){
    this._service.getRegistros(1).subscribe((res: any) => {
      this.dataSource.data = res.workLoadRegistries;
    })
  }

  addDebt(item){
    /* this._dialog.open(AddDoctorComponent, {
      width: '500px'
    }).afterClosed().subscribe(
      res => {
        this.getDoctors()
      }
    ); */
  }

}
