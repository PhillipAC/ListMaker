import { Entity } from "./entity";
import { Item } from "./item";

export class List extends Entity{
    constructor(
        public id: number,
        public name: string,
        public description: string,
        public items: Item[] = []
    ){
        super(id);
    }
}
