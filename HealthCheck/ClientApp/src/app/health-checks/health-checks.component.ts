import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-health-checks',
  templateUrl: './health-checks.component.html',
  styleUrls: ['./health-checks.component.css']
})
export class HealthChecksComponent implements OnInit{

  public result: Result;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  
  ngOnInit() {
    this.http.get<Result>(this.baseUrl + 'hc').subscribe(res => {
      this.result = res;
    }, error => console.log(error));
  }
}


interface Result{
  checks: Check[];
  totalStatus: string;
  totalResponseTime: number;
}

interface Check{
  name: string;
  status: string;
  responseTime: number;
  description: string;
}