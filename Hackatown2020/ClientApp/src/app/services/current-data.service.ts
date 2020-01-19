import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CurrentData } from '../Models/CurrentData';

@Injectable({
  providedIn: 'root'
})
export class CurrentDataService {
  res: CurrentData;

  constructor(private http: HttpClient) { }

  public async fetchData() {
    await this.http.get<CurrentData>(`/api/data/`)
    .toPromise()
    .then(x => {
      console.log(x);
      return x;
    })
    .catch(e => console.log(e));
  }
}
