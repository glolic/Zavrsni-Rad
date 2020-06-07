import { Drzava } from './drzava-model';

export class Natjecanje {
    public id: number;
    public imeNatjecanja: string;
    public drzava: Drzava;

    constructor(id?:number, imeNatjecanja?:string, drzava?: Drzava){
        this.id=id;
        this.imeNatjecanja=imeNatjecanja;
        this.drzava=drzava;
    }
}