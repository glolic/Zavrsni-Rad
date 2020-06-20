import { Stadion } from './stadion-model';
import { Lokacija } from './lokacija-model';

export class Klub {
    public id: number;
    public naziv: string;
    public godinaOsnivanja: number;
    public stadion: Stadion;
    public sjedisteKluba: Lokacija;

    constructor(id?:number, naziv?:string,
        godinaOsnivanja?:number, sjedisteKluba?:Lokacija, stadion?:Stadion){
        this.id=id;
        this.naziv=naziv;
        this.godinaOsnivanja=godinaOsnivanja;
        this.sjedisteKluba=sjedisteKluba;
        this.stadion=stadion;
    }
}