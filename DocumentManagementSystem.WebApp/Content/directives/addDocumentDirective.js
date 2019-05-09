var rootApp;
(function (rootApp) {
    var AddDocumentDirective = /** @class */ (function () {
        function AddDocumentDirective() {
            this.restrict = "E";
            this.templateUrl = '/Content/directives/add-document.html';
        }
        AddDocumentDirective.Factory = function () {
            return function () { return new AddDocumentDirective(); };
        };
        return AddDocumentDirective;
    }());
    rootApp.AddDocumentDirective = AddDocumentDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=addDocumentDirective.js.map