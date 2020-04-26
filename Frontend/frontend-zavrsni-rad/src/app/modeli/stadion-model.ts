import { Drzava } from './drzava-model';
import { Lokacija } from './lokacija-model';

export class Stadion {
    public id: number;
    public naziv: string;
    public kapacitet: number;
    public lokacija: Lokacija;

    constructor(id?:number, naziv?:string, kapacitet?: number, lokacija?:Lokacija){
        this.id=id;
        this.naziv=naziv;
        this.kapacitet=kapacitet;
        this.lokacija=lokacija;
    }
}