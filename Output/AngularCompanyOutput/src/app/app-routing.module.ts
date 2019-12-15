import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from './company/company.component'
import { HomeComponent } from './home/home.component'


const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'company/:id/:action', component: CompanyComponent
    },
    {path: 'company/:action', component: CompanyComponent },
    { path: '**', component: HomeComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
