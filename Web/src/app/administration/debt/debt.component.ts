import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { WorkLoadService } from '../services/work-load.service';

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
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      if(data) {
        this.contributorId = data
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
    /* if(!this.editable){
      this._service.addUser(model).subscribe((res: any)=>{
        this.toastr.success(res.message)
        this.dialogRef.close(true);
      })
    }
    else{
      this._service.updateUser(this.userId, model).subscribe((res: any)=>{
        this.toastr.success(res.message)
        this.dialogRef.close(true);
      })
    } */
  }
}
