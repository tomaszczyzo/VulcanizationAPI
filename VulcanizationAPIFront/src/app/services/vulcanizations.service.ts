import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Service } from '../Models/service.model';
import { Vulcanization } from '../Models/vulcanization.model';

@Injectable({
  providedIn: 'root'
})
export class VulcanizationsService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllVulcanizations(): Observable<Vulcanization[]> {
    return this.http.get<Vulcanization[]>(this.baseApiUrl + '/api/vulcanization');
  }
  getServices(id: number): Observable<Service[]> {
    return this.http.get<Service[]>(this.baseApiUrl+ '/api/vulcanization/' + id + '/service')
  }
}
