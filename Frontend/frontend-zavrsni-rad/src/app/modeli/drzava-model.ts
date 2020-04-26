export class Drzava {
    public id: number;
    public naziv: string;
    public oznaka: string;

    constructor(id?:number,naziv?:string, oznaka?:string){
        this.id=id;
        this.naziv=naziv;
        this.oznaka=oznaka;
    }
}