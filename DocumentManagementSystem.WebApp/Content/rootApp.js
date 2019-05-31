var rootApp;
(function (rootApp) {
    'use strict';
    angular.module('directiveModule', []).directive('addDocument', rootApp.DocumentDirective.Factory())
        .directive('documentsListing', rootApp.DocumentsListingDirective.Factory())
        .directive('informationDocument', rootApp.InformationDirective.Factory())
        .directive('documentTreeView', rootApp.DocumentTreeViewDirective.Factory())
        .directive('editDocument', rootApp.EditDocumentDirective.Factory());
    angular.module('controllerModule', ['directiveModule'])
        .controller('DocumentController', rootApp.DocumentController)
        .controller('RecycleBinController', rootApp.RecycleBinController);
    angular.module('routeModule', ['ngRoute']).config(['$routeProvider', '$locationProvider',
        function routes($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                templateUrl: 'Content/controllers/home.html',
                controller: 'DocumentController'
            })
                .when('/recycleBin', {
                templateUrl: 'Content/controllers/recycle-bin.html',
                controller: 'RecycleBinController'
            })
                .otherwise({
                redirectTo: '/'
            });
        }
    ]);
    angular.module('rootApp', ['controllerModule', 'directiveModule', 'routeModule']);
})(rootApp || (rootApp = {}));
//# sourceMappingURL=rootApp.js.map