var rootApp;
(function (rootApp) {
    var DocumentDirective = /** @class */ (function () {
        function DocumentDirective() {
            this.restrict = "E";
            this.templateUrl = '/Content/directives/add-document.html';
            this.controller = "DocumentController";
            this.controllerAs = "DocumentController";
            this.link = function (scope, element, attributes) {
            };
        }
        DocumentDirective.Factory = function () {
            return function () { return new DocumentDirective(); };
        };
        return DocumentDirective;
    }());
    rootApp.DocumentDirective = DocumentDirective;
    var DocumentController = /** @class */ (function () {
        function DocumentController(scope, element, attributes) {
            this.scope = scope;
            this.element = element;
            this.attributes = attributes;
        }
        DocumentController.prototype.uploadDocument = function () {
            var filePathInput = $("#addFile");
        };
        DocumentController.$inject = ["$scope", "$element", "$attributes"];
        return DocumentController;
    }());
    rootApp.DocumentController = DocumentController;
    angular.module('rootApp', [])
        .directive('addDocument', DocumentDirective.Factory());
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentDirective.js.map