import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkLoadsComponent } from './work-loads/work-loads.component';
import { ContributorsComponent } from './contributors/contributors.component';
import { WorkLoadComponent } from './work-load/work-load.component';
import { ContributorComponent } from './contributor/contributor.component';
import { CoreModule } from '../core/core.module';
import { AdministrationRoutingModule } from './administration-routing.module';

@NgModule({
  declarations: [WorkLoadsComponent, ContributorsComponent, WorkLoadComponent, ContributorComponent],
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    CoreModule
  ]
})
export class AdministrationModule { }
