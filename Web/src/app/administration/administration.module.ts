import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkLoadsComponent } from './work-loads/work-loads.component';
import { ContributorsComponent } from './contributors/contributors.component';
import { WorkLoadComponent } from './work-load/work-load.component';
import { ContributorComponent } from './contributor/contributor.component';
import { CoreModule } from '../core/core.module';
import { AdministrationRoutingModule } from './administration-routing.module';
import { DebtComponent } from './debt/debt.component';
import { PreviewComponent } from './preview/preview.component';

@NgModule({
  declarations: [WorkLoadsComponent, ContributorsComponent, WorkLoadComponent, ContributorComponent, DebtComponent, PreviewComponent],
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    CoreModule
  ],
  entryComponents: [
    DebtComponent,
    PreviewComponent
  ]
})
export class AdministrationModule { }
