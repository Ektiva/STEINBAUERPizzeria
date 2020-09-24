import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PizzaComponent } from './pizza/pizza.component';
import { HeaderComponent } from './header/header.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { HttpClientModule } from '@angular/common/http';
import {LayoutModule} from '@angular/cdk/layout';
import {MatDialogModule} from '@angular/material/dialog';
import { NewPizzaDialogComponent } from './new-pizza-dialog/new-pizza-dialog.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { DeletePizzaDialogComponent } from './delete-pizza-dialog/delete-pizza-dialog.component';

@NgModule({
   declarations: [
      AppComponent,
      PizzaComponent,
      HeaderComponent,
      NewPizzaDialogComponent,
      DeletePizzaDialogComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      MatToolbarModule,
      MatIconModule,
      MatGridListModule,
      MatCardModule,
      MatDividerModule,
      HttpClientModule,
      LayoutModule,
      MatDialogModule,
      MatFormFieldModule,
      FormsModule,
      MatInputModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
