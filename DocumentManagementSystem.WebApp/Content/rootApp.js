var rootApp;
(function (rootApp) {
    'use strict';
    angular.module('directiveModule', []).directive('addDocument', rootApp.DocumentDirective.Factory()).directive('documentsListing', rootApp.DocumentsListingDirective.Factory()).directive('informationDocument', rootApp.InformationDirective.Factory()).directive('documentTreeView', rootApp.documentTreeViewDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', rootApp.DocumentController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=rootApp.js.map