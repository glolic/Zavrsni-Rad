import { Partner } from './partneri-model';

export class PlacanjaPartnera {
    public id: number;
    public razlogPlacanja: string;
    public iznos: number;
    public placeno: boolean;
    public partner: Partner;

    constructor(id?:number, razlogPlacanja?:string, iznos?:number, partner?: Partner, placeno?: boolean){
        this.id=id;
        this.razlogPlacanja=razlogPlacanja;
        this.iznos=iznos;
        this.placeno=placeno;
        this.partner=partner;
    }
}