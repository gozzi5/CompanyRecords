import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { CompanyService } from './../services/company.service';
import { FormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.scss']
})
export class CompanyComponent implements OnInit {
    public action: any;
    public companyId: Number;
    public company: any;
    public res: any;
    public durationInSeconds: any
   
    constructor(private _snackBar: MatSnackBar,private activatedRoute: ActivatedRoute, private _companyService: CompanyService) {
        this.activatedRoute.params.subscribe(params => {
          
            this.action = params['action'];
            this.companyId = params['id'];
            this.company = {
                result: {}
            }

            

          
        });}

   
    ngOnInit() {
        this.onLoad();
    }

    openSnackBar(message,action) {
        this._snackBar.open(message, action, {
            duration: 2000,
            panelClass: ['yellow-snackbar']
        });
    }
    onLoad() {
      
        
        if (this.action =='view') {

            this.getCompanieById(this.companyId);
        } else if (this.action == 'edit') {

            this.getCompanieById(this.companyId);
        } else {

            this.action == 'new';
            this.company = {};

        }
    }

    saveCompany() {

        let company = this.company;
        if (this.action != 'new') {

            this._companyService.updateCompany(company).subscribe(
                data => {
                    this.res = data;
                    if (this.res.success) {

                        this.company = this.res.result;
                        this.openSnackBar("Saved", "");
                    } else {
                        this.openSnackBar(this.res.message, "");
                        console.log("waring")
                    }
                },
                err => console.error(err),
                () => console.log('done loading company')
            );
        } else {

            this._companyService.createCompany(company).subscribe(
                data => {
                    this.res = data;
                    if (this.res.success) {

                        this.company = this.res.result;
                        this.openSnackBar("Saved", "");
                    } else {
                        this.openSnackBar(this.res.message, "");
                        console.log("waring")
                    }
                },
                err => console.error(err),
                () => console.log('done loading company')
            );
        }

    }

    getCompanieById(id) {

        this._companyService.getCompanyById(id).subscribe(
            data => {
                this.res = data;
                if (this.res.success) {
                    this.company = this.res.result;
                } else {

                    console.log("waring")
                }                
            },
            err => console.error(err),
            () => console.log('done loading company')
        );

    }

}
