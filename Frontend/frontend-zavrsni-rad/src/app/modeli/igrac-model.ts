import { Pozicija } from './pozicija-model';
import { Osoba } from './osoba-model';
import { Momcad } from './momcad-model';

export class Igrac {
    public id: number;
    public osoba: Osoba;
    public pozicija: Pozicija;
    public brojDresa: number;
    public momcad: Momcad;

    constructor(id?:number, osoba?:Osoba, pozicija?: Pozicija, brojDresa?: number, momcad?: Momcad){
        this.id=id;
        this.osoba=osoba;
        this.pozicija=pozicija;
        this.brojDresa=brojDresa;
        this.momcad = momcad;
    }
}