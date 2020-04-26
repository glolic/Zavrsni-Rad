import { Klub } from './klub-model';

export class Momcad {
    public id: number;
    public naziv: string;
    public klub: Klub;

    constructor(id?:number, naziv?:string, klub?: Klub){
        this.id=id;
        this.naziv=naziv;
        this.klub=klub;
    }
}