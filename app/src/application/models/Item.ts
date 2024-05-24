export default class Item
{
    id: number;
    name: string;
    quantity: number;
    price: number;
    value: number;

    constructor(
        id: number,
        name: string,
        quantity: number,
        price: number,
        value: number
    )
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        this.price = price;
        this.value = value;
    }
}