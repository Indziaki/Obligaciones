import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { WorkLoadService } from '../services/work-load.service';
import { PreviewComponent } from '../preview/preview.component';

@Component({
  selector: 'app-debt',
  templateUrl: './debt.component.html',
  styleUrls: ['./debt.component.scss']
})
export class DebtComponent implements OnInit {

  rfc = ''
  contributor: any
  contributorId: string
  id: number
  obligations = []

  form = new FormGroup({
    contributorId: new FormControl('', Validators.required),
    rfc: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
    obligationId: new FormControl('', Validators.required),
    type: new FormControl('', Validators.required),
    taxType: new FormControl('', Validators.required),
    origin: new FormControl('', Validators.required),
    total: new FormControl('', Validators.required),
    validity: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required)
  })

  constructor(
    public dialogRef: MatDialogRef<DebtComponent>,
    private _service: WorkLoadService,
    private _dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      if(data) {
        this.contributorId = data.contributorId
        this.id = data.id
      }
    }

  ngOnInit() {
    this.getContributor()
    this.getObligations()
  }
  close(){
    this.dialogRef.close();
  }
  getContributor(){
    this._service.getContributor(this.contributorId).subscribe((res: any)=>{
      this.contributor = res;
      this.form.get('contributorId').setValue(this.contributorId)
      this.form.get('rfc').setValue(this.contributor.rfc)
      this.form.get('name').setValue(`${this.contributor.firstName} ${this.contributor.lastName}`)
    })
  }

  getObligations(){
    this._service.getObligations().subscribe((res: any[]) => {
      this.obligations = res;
    })
  }


  enviar(){
    let model = this.form.value;
    if(this.form.valid){
      this._service.addDebt(this.id, model).subscribe((res: any)=>{
        this.dialogRef.close(true);
      })
    }
  }

  preview(){
    let model = this.form.value
    model.obligation = this.obligations.find(x=>x.obligationId = model.obligationId)
    this._dialog.open(PreviewComponent, {
      width: '800px',
      data: model
    }).afterClosed().subscribe(
      res => {
        if(res) console.log(this.form.value)
      }
    );
  }
}
