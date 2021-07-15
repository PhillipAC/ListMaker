import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCreateComponent } from './components/list/list-create/list-create.component';
import { ListDetailsComponent } from './components/list/list-details/list-details.component';
import { ListIndexComponent } from './components/list/list-index/list-index.component';
import { ListUpdateComponent } from './components/list/list-update/list-update.component';

const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: ListIndexComponent},
  { path: 'list/create', component: ListCreateComponent},
  { path: 'list/:id', component: ListDetailsComponent},
  { path: 'list/:id/update', component: ListUpdateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
