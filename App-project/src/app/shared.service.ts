import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })

export class SharedService {

    private urlApi = 'http://localhost:5000/api/';

    constructor(
        private http: HttpClient
    ) { }
    

    GetAll() {
        const headers = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.http.get(this.urlApi + 'Person', { headers });
    }

    GetOne(id: number) {
        const headers = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.http.get(this.urlApi + 'Person/' + id, { headers });
    }

    Add(body: any) {
        const headers = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.http.post(this.urlApi + 'Person', body, { headers });
    }

    Update(id: number, body: any) {
        const headers = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.http.put(this.urlApi + 'Person/' + id, body, { headers });
    }

    Delete(id: number) {
        const headers = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.http.delete(this.urlApi + 'Person/' + id, { headers });
    }

}
