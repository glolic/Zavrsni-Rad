import { Drzava } from './drzava-model';

export class Lokacija {
    public id: number;
    public adresa: string;
    public drzava: Drzava;

    constructor(id?:number, adresa?:string, drzava?: Drzava){
        this.id=id;
        this.adresa=adresa;
        this.drzava=drzava;
    }
}