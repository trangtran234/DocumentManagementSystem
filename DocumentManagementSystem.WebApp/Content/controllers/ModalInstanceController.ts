module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IMyModalScope extends ng.IScope {
        document: Document;
    }

    export class ModalInstanceController {
        static $inject = ['$modalInstance', '$http', '$scope'];
        constructor(private $modalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private $http: ng.IHttpService, private $scope: IMyModalScope) {
        }
    }
}