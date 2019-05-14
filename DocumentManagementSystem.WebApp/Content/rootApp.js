var rootApp;
(function (rootApp) {
    'use strict';
    angular.module('directiveModule', []).directive('addDocument', rootApp.DocumentDirective.Factory());
    angular.module('controllerModule', ['directiveModule']).controller('DocumentController', rootApp.DocumentController).controller('TableController', rootApp.TableController);
    angular.module('rootApp', ['controllerModule', 'directiveModule']);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=rootApp.js.map