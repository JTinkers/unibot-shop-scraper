import { ref } from "vue";
import Shop from "../models/Shop";

const apiUrl = "http://localhost:5566/api/shops"
const wsUrl = "ws://localhost:5566/events"
const protocolMessage = `{"protocol": "json", "version": 1}`;

export default class ShopService
{
    shops = ref([] as Shop[]);

    constructor()
    {
        this.fetch();
        this.listen();
    }

    async listen()
    {
        const socket = new WebSocket(wsUrl);

        socket.addEventListener('open', () => 
        {
            socket.send(protocolMessage);
        }); 

        socket.addEventListener("message", (event) => 
        {
            const data = event.data.replace(/\u001e/g, '')
            const message = JSON.parse(data)

            if (message.target !== 'ShopStored')
                return;

            this.shops.value.push(...(message.arguments as Shop[]))
        })
    }

    async fetch()
    {
        const response = await fetch(apiUrl);
        const data = await response.json();

        this.shops.value = data as Shop[];
    }

    async remove(id: string)
    {
        this.shops.value = this.shops.value
            .filter(x => x.id != id);

        await fetch(
            apiUrl + `/?id=${id}`, 
            { 
                method: 'DELETE' 
            });
    }
}