export interface IPizza {
    id: string;
    name: string;
    pizzaDoughType: string;
    isCalzone: boolean;
    ingredientsList: string;
}

export class PizzaDto {
    id: string;
    name: string;
    pizzaDoughType: string;
    isCalzone: number;
    ingredientsList: string;
}