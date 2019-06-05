module rootApp {
    'user strict';

    import Document = rootApp.model.Document;

    interface IMyModalInstanceScope extends ng.IScope {
        document: Document;
        saveDocument: () => any;
        close: () => any;
    }

    export class ModalInstanceController {
        static $inject = ['$uibModalInstance', '$http', '$scope', '$rootScope', 'id', 'parentId'];
        constructor(private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private $http: ng.IHttpService, private $scope: IMyModalInstanceScope,
            private $rootScope: ng.IRootScopeService, public id, public parentId) {

            $http.get<Document>('/api/documents/DocumentById/' + id)
                .then((response: ng.IHttpPromiseCallbackArg<Document>) => {
                    $scope.document = response.data;
                });

            $scope.saveDocument = function () {
                $http.post('/api/documents/UpdateDocument', $scope.document)
                    .then(function (response) {
                        $rootScope.$broadcast('rootScope:successEditDocument', $scope.document);
                    });
                $uibModalInstance.close();
            }

            $scope.close = function () {
                $uibModalInstance.dismiss();
            }
        }
    }
}