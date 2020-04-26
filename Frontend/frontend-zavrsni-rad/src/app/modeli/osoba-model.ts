import { Spol } from './spol-model';
import { Drzava } from './drzava-model';
import { Uloga } from './uloga-model';

export class Osoba {
    public id: number;
    public ime: string;
    public prezime: string;
    public datumRodenja: Date;
    public oib: string;
    public spol: Spol;
    public drzavaRodenja: Drzava;
    public uloga: Uloga;

    constructor(id?:number, ime?:string, prezime?:string
        ,datumRodenja?:Date, oib?:string, spol?:Spol, drzavaRodenja?: Drzava, uloga?:Uloga){
        this.id=id;
        this.ime=ime;
        this.prezime=prezime;
        this.datumRodenja=datumRodenja;
        this.oib=oib;
        this.spol=spol;
        this.drzavaRodenja=drzavaRodenja;
        this.uloga=uloga;
    }
}