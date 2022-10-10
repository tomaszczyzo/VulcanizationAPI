import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Service } from '../Models/service.model';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllServices(id: number): Observable<Service[]> {
    return this.http.get<Service[]>(this.baseApiUrl + '/api/vulcanization/' + id + '/service');
  }


}
