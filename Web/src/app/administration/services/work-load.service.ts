import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WorkLoadService {

  private api = `${environment.api}/User`;
  private apiOb = `${environment.api}/Obligation`;
  private apiCont = `${environment.api}/Contributor`;

  constructor(private _http: HttpClient) { }

  getAll(){
    return this._http.get(`${this.api}/Cargas`)
  }
  getRegistros(id){
    return this._http.get(`${this.api}/Carga/${id}`)
  }
  getObligations(){
    return this._http.get(`${this.apiOb}`)
  }
  getContributor(id){
    return this._http.get(`${this.apiCont}/${id}`)
  }
  add(model){
    return this._http.post(`${this.api}/Carga`, model)
  }
  addRegistros(id, model){
    return this._http.post(`${this.api}/Carga/Registros/${id}`, model)
  }
}
