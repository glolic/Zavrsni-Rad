import { Momcad } from './momcad-model';
import { Natjecanje } from './natjecanje-model';

export class Uloga {
    public id: number;
    public momcad1: Momcad;
    public momcad2: Momcad;
    public datumUtakmice: Date;
    public rezultat: string;
    public natjecanje: Natjecanje;
    public brojPosjetitelja: number;

    constructor(id?:number, momcad1?:Momcad, momcad2?:Momcad,
        datumUtakmice?: Date, rezultat?: string, natjecanje?: Natjecanje, brojPosjetitelja?: number){
        this.id=id;
        this.momcad1 = momcad1;
        this.momcad2 = momcad2;
        this.datumUtakmice=datumUtakmice;
        this.rezultat=rezultat;
        this.natjecanje=natjecanje;
        this.brojPosjetitelja=brojPosjetitelja;
    }
}