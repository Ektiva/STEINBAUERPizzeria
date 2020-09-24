import { Injectable } from '@angular/core';
import { IPizza } from '../_models/pizza';
import { HttpClient } from '@angular/common/http';
import { of, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  baseUrl = 'https://localhost:44347/api/';

  // pizzas = new BehaviorSubject<Array<IPizza>>([]);
  // currentPizzas = this.pizzas.asObservable();

constructor(private http: HttpClient) { }

// changePizzas(pizzas: IPizza[]){
//   this.pizzas.next(pizzas);
// }

getPizza(id: number) {
  return this.http.get<IPizza>(this.baseUrl + 'pizzas/' + id);
}

getPizzas() {
  return this.http.get<IPizza[]>(this.baseUrl + 'pizzas');
}

createPizza(pizza: any) {
  return this.http.post<IPizza[]>(this.baseUrl + 'pizzas', pizza);
}

editPizza(pizza: any) {
  return this.http.put<IPizza[]>(this.baseUrl + 'pizzas/' + pizza.id, pizza);
}

deletePizza(id: string) {
  return this.http.delete<IPizza[]>(this.baseUrl + 'pizzas/' + id);
}

}
