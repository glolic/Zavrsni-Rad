import { Lokacija } from './lokacija-model';

export class Partner {
    public id: number;
    public nazivPartnera: string;
    public lokacija: Lokacija;

    constructor(id?:number, nazivPartnera?:string, lokacija?:Lokacija){
        this.id=id;
        this.nazivPartnera=nazivPartnera;
        this.lokacija=lokacija;
    }
}