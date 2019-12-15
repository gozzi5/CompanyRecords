import { Component } from '@angular/core';
import { CompanyService } from './services/company.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
    title = 'CompanyRecords';
  
    constructor(private _companyService: CompanyService) { }


    ngOnInit() {
    this.title = "Companies Records"
   
    }

 



}
