import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Client } from '../Models/client';
import { Observable } from 'rxjs';
import { ClientAdd } from '../Models/client-add';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http : HttpClient) { }
  url= "http://localhost:5013/api/Client";

  getClients(pageNumber: number, pageSize: number): Observable<{ data: Client[], totalItems: number }> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<{ data: Client[], totalItems: number }>(this.url, { params });
  }
  DeleteClient(id:number){
    return this.http.delete<any>(`${this.url}/${id}`)
  }

  Addclient(Newclient:ClientAdd){
    return this.http.post<any>(this.url,Newclient);
  }

  GetClientById(id:number){
    return this.http.get<any>(`${this.url}/${id}`);
  }

  EditClient(EditClient:Client){
    return this.http.put<any>(this.url,EditClient)
  }
 
}
