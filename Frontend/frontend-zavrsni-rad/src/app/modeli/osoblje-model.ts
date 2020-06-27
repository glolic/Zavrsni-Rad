import { Osoba } from './osoba-model';
import { Momcad } from './momcad-model';

export class Osoblje {
    public id: number;
    public osoba: Osoba;
    public momcad: Momcad;
    public dozvolaZaRad: boolean;
    public datumIstekaDozvole: Date;

    constructor(id?:number, osoba?:Osoba, momcad?:Momcad, dozvolaZaRad?:boolean, datumIstekaDozvole?:Date){
        this.id=id;
        this.osoba=osoba;
        this.momcad = momcad;
        this.dozvolaZaRad = dozvolaZaRad;
        this.datumIstekaDozvole = datumIstekaDozvole;
    }
}