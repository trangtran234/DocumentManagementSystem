module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory()).directive('documentsList', DocumentsListingDirective.Factory()).directive('informationDocumentTag', InformationDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', DocumentController).controller('DocumentsListingController', DocumentsListingController).controller('InformationController', InformationController).controller('TreeViewController', TreeViewController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
}