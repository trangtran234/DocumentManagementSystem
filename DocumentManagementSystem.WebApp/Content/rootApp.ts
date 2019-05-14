module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', DocumentController).controller('TableController', TableController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
    
}