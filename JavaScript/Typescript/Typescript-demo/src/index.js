"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var mtgservice_1 = require("./mtgservice");
var Main = /** @class */ (function () {
    function Main() {
    }
    Main.Main = function () {
        console.log("main");
        document.addEventListener('DOMContentLoaded', function () {
            console.log("dom content loaded");
            var mtgService = new mtgservice_1.MtgService("https://api.scryfall.com");
            var textField = document.getElementById('textField');
            var button = document.getElementById('button');
            var output = document.getElementById('output');
            button.addEventListener('click', function () {
                console.log("clicked button");
                mtgService.getByName(textField.value, function (card) {
                    output.textContent = card.name;
                });
            });
        });
    };
    return Main;
}());
Main.Main();
