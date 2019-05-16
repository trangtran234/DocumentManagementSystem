module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
    }

    export class InformationController {
        static $inject = ['$scope'];

        constructor(private $scope: IMyDocumentScope) {
            $scope.$on('rootScope:documentInfo', function (event, data) {
                $scope.document = data;
            });
        }
    }
}