import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkLoadsComponent } from './work-loads/work-loads.component';
import { ContributorsComponent } from './contributors/contributors.component';
import { AuthGuard } from '../auth/guards/auth.guard';

const routes: Routes = [
  {path: '', redirectTo: 'workloads', pathMatch: 'full'},
  {path: 'workloads', component: WorkLoadsComponent, canActivate: [AuthGuard]},
  {path: 'contributors', component: ContributorsComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
