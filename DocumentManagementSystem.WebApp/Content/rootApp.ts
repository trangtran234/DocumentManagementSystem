module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory())
        .directive('documentsListing', DocumentsListingDirective.Factory())
        .directive('informationDocument', InformationDirective.Factory())
        .directive('documentTreeView', DocumentTreeViewDirective.Factory())
        .directive('editDocument', EditDocumentDirective.Factory());

    angular.module('controllerModule', ['directiveModule'])
        .controller('DocumentController', DocumentController)
        .controller('RecycleBinController', RecycleBinController);

    //angular.module('routeModule', []).config(ConfigureRoutes);

    angular.module('routeModule', ['ngRoute']).config(['$routeProvider',
        function routes($routeProvider: ng.route.IRouteProvider) { 
            $routeProvider
                .when('/', {
                    templateUrl: 'Content/controllers/home.html',
                    controller: 'DocumentController'
                })
                .when('/RecycleBin', {
                    templateUrl: 'Content/controllers/recycle-bin.html',
                })
                .otherwise({
                    redirectTo: '/'
                });
        }
    ]);

    angular.module('rootApp', ['controllerModule', 'directiveModule','routeModule']);
}