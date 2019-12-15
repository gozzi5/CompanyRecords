import {Injectable,Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
 
const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
 
@Injectable()
export class CompanyService {
    _baseUrl
    constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string) {

        this._baseUrl = baseUrl;
    }
 
    getCompanies() {
        return this.http.get(this._baseUrl+'api/Company/getCompanies');
    }
    getCompanyById(id) {
        return this.http.get(this._baseUrl + 'api/Company/GetCompanyById?id='+id);
    }
    getCompanyByIsin(isin: string) {
        return this.http.get(this._baseUrl + 'api/Company/GetCompanyByIsin?isin='+isin);
    }
    updateCompany(company: any) {
        return this.http.put(this._baseUrl + 'api/Company/updateCompany', company);
    }
    createCompany(company: any) {
        return this.http.post(this._baseUrl + 'api/Company/createCompany', company);
    }
}
