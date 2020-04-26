import { Osoba } from './osoba-model';

export class Osoblje {
    public id: number;
    public osoba: Osoba;

    constructor(id?:number, osoba?:Osoba){
        this.id=id;
        this.osoba=osoba;
    }
}