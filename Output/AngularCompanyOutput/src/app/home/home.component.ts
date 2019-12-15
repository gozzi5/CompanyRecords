import { Component, OnInit } from '@angular/core';
import { CompanyService } from './../services/company.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

 

    public companies: any;
    public company: any;
    public loading: boolean;
    public isin: string;
    constructor(private _companyService: CompanyService) {
        this.companies = {

            results:[]
        }

    }


    ngOnInit() {     
        this.getCompanies()
    }

    getCompanies() {
        this.loading = true;
        this._companyService.getCompanies().subscribe(
            data => {
             
                this.companies = data

                this.loading = false;
            },
            err => console.error(err),
            () => console.log('done loading companies')
        );

    }
   
    getCompanieByIsin() {
        let isin = this.isin;
        this._companyService.getCompanyByIsin(isin).subscribe(
            data => {
              
                this.company = data;
                this.companies.results = [];

                //adding the single result into the table
                if (this.company.success == true) {
                    this.companies.results.push(this.company.result);
                } else {


                }
            },
            err => console.error(err),
            () => console.log('done loading companies')
        );

    }

}
