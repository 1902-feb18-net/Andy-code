import { Card } from "./card";

export class MtgService {
    url: string;

    getByName(name: string, onSuccess: (card: Card) => void ) : void {
        let fragment = '/cards/named'
        let url = `${this.url}${fragment}?fuzzy=${name}`
        fetch(this.url).then(r => r.json())
        .then(onSuccess)
        .catch(error => console.log(error));
    }

    constructor(url: string) {
        this.url = url;
    }
}