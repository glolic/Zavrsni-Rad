export class Drzava {
    public id: number;
    public nazivDrzave: string;
    public oznaka: string;

    constructor(id?:number,nazivDrzave?:string, oznaka?:string){
        this.id=id;
        this.nazivDrzave=nazivDrzave;
        this.oznaka=oznaka;
    }
}