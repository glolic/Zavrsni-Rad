import { Drzava } from './drzava-model';
import { Stadion } from './stadion-model';

export class Klub {
    public id: number;
    public naziv: string;
    public godinaOsnivanja: Date;
    public stadion: Stadion;
    public sjedisteKluba: Drzava;

    constructor(id?:number, naziv?:string,
        godinaOsnivanja?:Date, sjedisteKluba?:Drzava, stadion?:Stadion){
        this.id=id;
        this.naziv=naziv;
        this.godinaOsnivanja=godinaOsnivanja;
        this.sjedisteKluba=sjedisteKluba;
        this.stadion=stadion;
    }
}