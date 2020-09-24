import { IPizza } from './_models/pizza';

export interface AppState {
  readonly pizza: IPizza[];
}