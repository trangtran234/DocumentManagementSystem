var rootApp;
(function (rootApp) {
    'use strict';
    var InformationDirective = /** @class */ (function () {
        //public scope = {
        //    documentInfo: '=info'
        //};
        function InformationDirective() {
            this.restrict = "E";
            this.templateUrl = '/Content/directives/informationDocument.html';
            this.link = function (scope, element, attributes) {
                scope.isVisible = false;
                scope.$on('rootScope:documentInfo', function (event, data) {
                    scope.document = data;
                });
                scope.$on('rootScope:isVisible', function (event, data) {
                    scope.isVisible = data;
                });
            };
        }
        InformationDirective.Factory = function () {
            return function () { return new InformationDirective(); };
        };
        return InformationDirective;
    }());
    rootApp.InformationDirective = InformationDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=informationDirective.js.map