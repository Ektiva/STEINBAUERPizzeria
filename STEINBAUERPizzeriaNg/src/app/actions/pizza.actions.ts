// Section 1
import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { IPizza } from 'src/app/_models/pizza';

// Section 2
export const ADD_PIZZA       = '[PIZZA] Add';
export const REMOVE_PIZZA    = '[PIZZA] Remove';

// Section 3
export class AddPizza implements Action {
    readonly type = ADD_PIZZA

    constructor(public payload: IPizza) {}
}

export class RemovePizza implements Action {
    readonly type = REMOVE_PIZZA

    constructor(public payload: number) {}
}

// Section 4
export type Actions = AddPizza| RemovePizza