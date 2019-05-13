var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentDirective = /** @class */ (function () {
        function DocumentDirective() {
            this.restrict = "E";
            this.templateUrl = '/Content/directives/add-document.html';
            this.link = function (scope, element, attributes) {
            };
        }
        DocumentDirective.Factory = function () {
            return function () { return new DocumentDirective(); };
        };
        return DocumentDirective;
    }());
    rootApp.DocumentDirective = DocumentDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentDirective.js.map