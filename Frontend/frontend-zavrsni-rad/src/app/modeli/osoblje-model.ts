import { Osoba } from './osoba-model';
import { Momcad } from './momcad-model';

export class Osoblje {
    public id: number;
    public osoba: Osoba;
    public momcad: Momcad;
    public datumIzdajeDozvole: Date;
    public datumIstekaDozvole: Date;

    constructor(id?:number, osoba?:Osoba, momcad?:Momcad, datumIzdajeDozvole?:Date, datumIstekaDozvole?:Date){
        this.id=id;
        this.osoba=osoba;
        this.momcad = momcad;
        this.datumIzdajeDozvole = datumIzdajeDozvole;
        this.datumIstekaDozvole = datumIstekaDozvole;
    }
}