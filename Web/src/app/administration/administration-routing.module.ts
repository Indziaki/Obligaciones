import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkLoadsComponent } from './work-loads/work-loads.component';
import { ContributorsComponent } from './contributors/contributors.component';

const routes: Routes = [
  {path: '', redirectTo: 'workloads'},
  {path: 'workloads', component: WorkLoadsComponent, pathMatch: 'full'},
  {path: 'contributors', component: ContributorsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
