import { Partner } from './partneri-model';

export class PlacanjaPartnera {
    public id: number;
    public razlogPlacanja: string;
    public iznos: number;
    public datumPlacanja: Date;
    public partner: Partner;

    constructor(id?:number, razlogPlacanja?:string, iznos?:number, partner?: Partner, datumPlacanja?: Date){
        this.id=id;
        this.razlogPlacanja=razlogPlacanja;
        this.iznos=iznos;
        this.datumPlacanja=datumPlacanja;
        this.partner=partner;
    }
}