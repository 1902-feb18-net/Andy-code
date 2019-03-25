"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var MtgService = /** @class */ (function () {
    function MtgService(url) {
        this.url = url;
    }
    MtgService.prototype.getByName = function (name, onSuccess) {
        var fragment = '/cards/named';
        var url = "" + this.url + fragment + "?fuzzy=" + name;
        fetch(this.url).then(function (r) { return r.json(); })
            .then(onSuccess)
            .catch(function (error) { return console.log(error); });
    };
    return MtgService;
}());
exports.MtgService = MtgService;
