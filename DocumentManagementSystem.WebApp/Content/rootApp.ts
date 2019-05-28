module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory())
        .directive('documentsListing', DocumentsListingDirective.Factory())
        .directive('informationDocument', InformationDirective.Factory())
        .directive('documentTreeView', DocumentTreeViewDirective.Factory())
        .directive('editDocument', EditDocumentDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', DocumentController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
}