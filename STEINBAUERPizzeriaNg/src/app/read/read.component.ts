import { Component, OnInit } from '@angular/core';

// import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { IPizza } from '../_models/pizza';
import { AppState } from './../app.state';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-read',
  templateUrl: './read.component.html',
  styleUrls: ['./read.component.scss']
})
export class ReadComponent implements OnInit {

  // Section 1
  pizzas: Observable<IPizza[]>;

  // Section 2
  constructor(private store: Store<AppState>) { 
    this.pizzas = store.select('pizza');
  }

  ngOnInit() {
  }

}
