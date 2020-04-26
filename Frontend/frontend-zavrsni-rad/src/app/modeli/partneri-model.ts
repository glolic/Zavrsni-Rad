import { Lokacija } from './lokacija-model';

export class Partner {
    public id: number;
    public naziv: string;
    public lokacija: Lokacija;

    constructor(id?:number, naziv?:string, lokacija?:Lokacija){
        this.id=id;
        this.naziv=naziv;
        this.lokacija=lokacija;
    }
}