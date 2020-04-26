import { Drzava } from './drzava-model';

export class Natjecanje {
    public id: number;
    public nazivNatjecanja: string;
    public drzava: Drzava;

    constructor(id?:number, nazivNatjecanja?:string, drzava?: Drzava){
        this.id=id;
        this.nazivNatjecanja=nazivNatjecanja;
        this.drzava=drzava;
    }
}