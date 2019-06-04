module rootApp {
    'use strict';

    angular.module('directiveModule', []).directive('addDocument', DocumentDirective.Factory())
        .directive('documentsListing', DocumentsListingDirective.Factory())
        .directive('informationDocument', InformationDirective.Factory())
        .directive('documentTreeView', DocumentTreeViewDirective.Factory());

    angular.module('controllerModule', ['directiveModule'])
        .controller('DocumentController', DocumentController)
        .controller('RecycleBinController', RecycleBinController)
        .controller('ModalInstanceController', ModalInstanceController);

    angular.module('routeModule', ['ngRoute']).config(['$routeProvider','$locationProvider',
        function routes($routeProvider: ng.route.IRouteProvider, $locationProvider: ng.ILocationProvider) { 
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

    angular.module('rootApp', ['controllerModule', 'directiveModule', 'routeModule', 'ui.bootstrap', 'ngSanitize']);
}