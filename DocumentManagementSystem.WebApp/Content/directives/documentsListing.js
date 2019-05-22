var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentsListingDirective = /** @class */ (function () {
        function DocumentsListingDirective() {
            this.restrict = "E";
            this.templateUrl = '/Content/directives/tableListView.html';
        }
        DocumentsListingDirective.Factory = function () {
            return function () { return new DocumentsListingDirective(); };
        };
        return DocumentsListingDirective;
    }());
    rootApp.DocumentsListingDirective = DocumentsListingDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentsListing.js.map