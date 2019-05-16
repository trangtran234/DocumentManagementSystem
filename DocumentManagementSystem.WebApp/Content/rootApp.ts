module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory()).directive('tableListView', TableListViewDirective.Factory()).directive('informationDocumentTag', InformationDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', DocumentController).controller('TableController', TableController).controller('InformationController', InformationController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
}