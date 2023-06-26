import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CdbResultModel } from 'src/app/models/CdbResultModel';
import { Observable } from 'rxjs/internal/Observable';
import { CdbCommandModel } from 'src/app/models/CdbCommandModel';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private _http: HttpClient) { }

  urlBase = "http://localhost:5243/api"
  calcularCDB(model: CdbCommandModel): Observable<CdbResultModel> {
    return this._http.post<CdbResultModel>(`${this.urlBase}/cdb/calcular`, model)
  }
}
