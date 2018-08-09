import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs/Rx';
import 'rxjs/Rx';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public quote: Quote[];
  pollingData: any; 

  constructor(private http: HttpClient,  @Inject('BASE_URL') private baseUrl: string) { 
      this.pollingData = Observable.interval(8000)
      .switchMap(() => http.get<Quote[]>(this.baseUrl + 'api/Quote'))
      .subscribe(result => {
        this.quote = result;
      }, error => console.error(error))

   }

   ngOnDestroy() {
    this.pollingData.unsubscribe();
   }
}

interface Quote {
  author: string;
  id: number;
  quote: string;
  permaLink: string;
}
