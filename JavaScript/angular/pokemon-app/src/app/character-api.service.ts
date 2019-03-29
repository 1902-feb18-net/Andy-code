import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Character } from './models/character';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CharacterApiService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Character[]> {
    let baseUrl = environment.charApiUrl;
    console.log(`Making req at API url ${baseUrl}`);
    let url = `${baseUrl}/api/character`;

    return this.http.get<Character[]>(url, {withCredentials: true});
  }
  login(login: Login): Observable<{}> {
    let url = `${environment.charApiUrl}/api/account/login`;
    return this.http.post(url, login, { withCredentials: true }).pipe(res => {
      let url = `${environment.charApiUrl}/api/account/details`;
      return this.http.get<Account>(url, {withCredentials: true}).pipe(account => {
        // when we get that save in session storage, the logged in user's info
        // so if client refreshes page, we still have it
        sessionStorage['account'] = account;
        // return the account details to the one calling this method
        return account;
      })
    });
  }
}
