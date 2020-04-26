import { Pozicija } from './pozicija-model';
import { Osoba } from './osoba-model';

export class Igrac {
    public id: number;
    public osoba: Osoba;
    public pozicija: Pozicija;
    public brojDresa: number;

    constructor(id?:number, osoba?:Osoba, pozicija?: Pozicija, brojDresa?: number){
        this.id=id;
        this.osoba=osoba;
        this.pozicija=pozicija;
        this.brojDresa=brojDresa;
    }
}