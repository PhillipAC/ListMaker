import { Entity } from "./entity";

export class Item extends Entity {
    constructor(
        public id: number,
        public name: string,
        public itemListId: number,
        public order: number,
        public isChecked: boolean
    ){
        super(id);
    }
}
