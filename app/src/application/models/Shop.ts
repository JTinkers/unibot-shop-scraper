import Item from "./Item";
import Player from "./Player";

export default class Shop
{
    id: string;
    name: string;
    owner: Player;
    items: Item[];
    position: 
    { 
        x: number; 
        y: number; 
    }

    constructor(
        id: string,
        name: string,
        owner: Player,
        items: Item[],
        position: { x: number, y: number }
    ) 
    {
        this.id = id;
        this.name = name;
        this.owner = owner;
        this.position = position;
        this.items = items;
    }
}