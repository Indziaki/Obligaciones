import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.scss']
})
export class PreviewComponent implements OnInit {

  debt: any
  now = new Date()

  constructor(
    public _dialogRef: MatDialogRef<PreviewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if(data) this.debt = data
  }

  ngOnInit() {
  }
  cancel(){
    this._dialogRef.close()
  }
  close(){
    this._dialogRef.close(true)
  }


}
