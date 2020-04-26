export class Pozicija {
    public id: number;
    public naziv: string;

    constructor(id?:number, naziv?:string){
        this.id=id;
        this.naziv=naziv;
    }
}