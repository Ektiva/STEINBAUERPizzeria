import { Component, OnInit } from '@angular/core';
import { PizzaService } from './pizza.service';
import { IPizza } from '../_models/pizza';
import { BreakpointObserver, BreakpointState, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { NewPizzaDialogComponent } from '../new-pizza-dialog/new-pizza-dialog.component';
import { DeletePizzaDialogComponent } from '../delete-pizza-dialog/delete-pizza-dialog.component';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.scss']
})

export class PizzaComponent implements OnInit {
  pizzas: Array<IPizza> = [];
  pizza: IPizza;
  isMobile: Observable<BreakpointState>;
  id: string;
  name: string;
  pizzaDoughType: string;
  isCalzone: boolean;
  ingredientsList: string;
  edit = false;

  constructor(
    public dialog: MatDialog,
    public dialog1: MatDialog,
    private pizzaService: PizzaService,
    private breakpointObserver: BreakpointObserver)
     { }
  
     openDialog(pizza?: IPizza): void {
      if(pizza){
        // this.id = pizza.id;
        // this.name = pizza.name;
        // this.ingredientsList = pizza.ingredientsList;
        // this.isCalzone = pizza.isCalzone;
        // this.pizzaDoughType = pizza.pizzaDoughType;
        // this.edit = true;

        const dialogRef = this.dialog.open(NewPizzaDialogComponent, {
          width: '300px',
          data: {id: pizza.id, name: pizza.name, pizzaDoughType: pizza.pizzaDoughType, isCalzone: pizza.isCalzone, 
            ingredientsList: pizza.ingredientsList, edit: true}
        });
    
        dialogRef.afterClosed().subscribe(result => {
          this.getPizzas();
          console.log('The dialog was closed');
        });
      }else{
        const dialogRef = this.dialog.open(NewPizzaDialogComponent, {
          width: '300px',
          data: {id: this.id, name: this.name, pizzaDoughType: this.pizzaDoughType, isCalzone: this.isCalzone, 
            ingredientsList: this.ingredientsList, edit: this.edit}
        });
    
        dialogRef.afterClosed().subscribe(result => {
          this.getPizzas();
          console.log('The dialog was closed');
        });
      }
     
    }

    
    openDeleteDialog(Id: string): void {
      const dialogRef1 = this.dialog1.open(DeletePizzaDialogComponent, {
        width: '250px',
        data: {id: Id}
      });
  
      dialogRef1.afterClosed().subscribe(result => {
        this.getPizzas();
        console.log(`Dialog result: ${result}`);
      });
    }

  ngOnInit(): void {
    console.log('Yes init...');
    this.isMobile = this.breakpointObserver.observe(Breakpoints.Handset);
    this.getPizzas();
  }

  getPizzas() {
    this.pizzaService.getPizzas().subscribe(response => {
      this.pizzas = response;
    }, error => {
      console.log(error);
    });
  }
}
