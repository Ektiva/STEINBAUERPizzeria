import { Component, OnInit, Inject } from '@angular/core';
import { PizzaService } from '../pizza/pizza.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-pizza-dialog',
  templateUrl: './delete-pizza-dialog.component.html',
  styleUrls: ['./delete-pizza-dialog.component.scss']
})
export class DeletePizzaDialogComponent implements OnInit {

  constructor(
    private pizzaService: PizzaService,
    public dialogRef: MatDialogRef<DeletePizzaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit() {
  }

  deletePizza(data: any) {
    this.pizzaService.deletePizza(data.id).subscribe(response => {

    }, error => {
      console.log(error);
    });
  }

}
