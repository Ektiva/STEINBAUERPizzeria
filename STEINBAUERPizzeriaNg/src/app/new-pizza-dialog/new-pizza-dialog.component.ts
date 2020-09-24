import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IPizza, PizzaDto } from '../_models/pizza';
import { PizzaService } from '../pizza/pizza.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-new-pizza-dialog',
  templateUrl: './new-pizza-dialog.component.html',
  styleUrls: ['./new-pizza-dialog.component.scss']
})
export class NewPizzaDialogComponent implements OnInit {
  pizzaDto: PizzaDto  = new PizzaDto();
  pizzas: Array<IPizza> = [];

  ingredients = new Map<string, string>();

  constructor(
    private pizzaService: PizzaService,
    public dialogRef: MatDialogRef<NewPizzaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit() {
    this.ingredients.set('Pineapple Pizza with ham, bacon, pineapple & mozzarella cheese.', 'HOWIE_MAUI');
    this.ingredients.set('Sweet BBQ sauce, grilled chicken breast, bacon, red onions & mozzarella cheese.', 'BBQ_CHICKEN' );
    this.ingredients.set('Pepperoni, ham, mushrooms, red onions, green peppers & mozzarella cheese.', 'HOWIE_SPECIAL');
    this.ingredients.set('Mushrooms, red onions, green peppers, tomatoes, black olives & mozzarella cheese.', 'VEGGIE' );
    this.ingredients.set('Grilled chicken breast, bacon & mozzarella cheese with ranch dressing.', 'CHICKEN_BACON_RANCH' );
    this.ingredients.set('Ground beef, bacon, mozzarella & cheddar cheese.',  'BACON_CHEDDAR_CHEESEBURGER');
    this.ingredients.set('Spicy buffalo sauce, grilled chicken breast, red onions, mozzarella & cheddar cheese.', 'BUFFALO_CHICKEN' );
    this.ingredients.set('Tangy Asian sauce, grilled chicken breast, red onions, green peppers, sesame seeds & mozzarella cheese.',  'ASIAN_CHICKEN');
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  savePizza(pizza: IPizza) {
    this.setPizzaToSave(pizza);
    if(this.data.edit){
      this.pizzaService.editPizza(this.pizzaDto).subscribe(response => {
      }, error => {
        console.log(error);
      });
    }else{
      this.pizzaService.createPizza(this.pizzaDto).subscribe(response => {
      }, error => {
        console.log(error);
      });
    }
    // this.getPizzas().subscribe(res => {
    //   this.pizzaService.changePizzas(res);

    // });
  }

  setPizzaToSave(pizza: IPizza) {
    console.log(pizza);
    if(this.data.edit)
    {
      this.pizzaDto.id = pizza.id
    }else{
      this.pizzaDto.id = ''+Math.floor(Math.random() * 100) + 1 + ''+pizza.name[0] + 
        ''+pizza.pizzaDoughType[0] + ''+pizza.ingredientsList[0];
    }
    this.pizzaDto.name = pizza.name;
    this.pizzaDto.isCalzone = (pizza.isCalzone.toString() === 'true') ? 1 : 0;
    this.pizzaDto.pizzaDoughType = (pizza.pizzaDoughType.toString() === 'New York Style') ? 'NewYorkStyle' : pizza.pizzaDoughType;
    this.pizzaDto.ingredientsList = this.ingredients.get(pizza.ingredientsList); 
  }

  // getPizzas() {
  //   return this.pizzaService.getPizzas().pipe(tap((response) => {
  //     this.pizzas = response;
  //   }, error => {
  //     console.log(error);
  //   }));   
  // }

}
