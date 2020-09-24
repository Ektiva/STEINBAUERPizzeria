import { Action } from '@ngrx/store'
import * as PizzaActions from './../actions/pizza.actions'
import { IPizza } from 'src/app/_models/pizza';

// Section 1
const initialState: IPizza = {
    id: '18MNH',
    name: 'Maui New York Pizza',
    pizzaDoughType: 'NewYorkStyle',
    isCalzone: true,
    ingredientsList: 'HOWIE_MAUI'
}

// Section 2
export function reducer(state: IPizza[] = [initialState], action: PizzaActions.Actions) {

    // Section 3
    switch(action.type) {
        case PizzaActions.ADD_PIZZA:
            return [...state, action.payload];
        default:
            return state;
    }
}