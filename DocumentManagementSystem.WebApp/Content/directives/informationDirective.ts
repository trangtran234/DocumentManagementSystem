module rootApp {
    'use strict';

    import Document = rootApp.model.Document;
    import DocumentHistory = rootApp.model.DocumentHistory;

    interface IMyDocumentScope extends ng.IScope {
        document: Document;
        isVisible: boolean;
        documentHistories;
        messages;
        getDocumentHistories: () => void;
    }

    export class InformationDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/informationDocument.html';

        constructor(private $http: ng.IHttpService, private $sce: ng.ISCEService, private $filter: ng.IFilterService) { }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService, $sce: ng.ISCEService, $filter: ng.IFilterService) => new InformationDirective($http, $sce, $filter);
            directive.$inject = ['$http', '$sce', '$filter'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IMyDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {
            scope.isVisible = false;
            scope.$on('rootScope:documentInfo', function (event, data) {
                scope.document = data;
            });
            scope.$on('rootScope:isVisible', function (event, data) {
                scope.isVisible = data;
            });

            var http = this.$http;
            var sce = this.$sce;
            var filter = this.$filter;
            scope.documentHistories = new Array<DocumentHistory>();
            scope.messages = new Array<string>();
            

            scope.$on('history:sucessed', function (event, data) {
                var actionEvent = data;
                if (actionEvent !== null) {
                    scope.getDocumentHistories();
                }
            });

            scope.getDocumentHistories = () => {
                http.get<DocumentHistory[]>('/api/documents/DocumentHistories')
                    .then((response: ng.IHttpPromiseCallbackArg<DocumentHistory[]>) => {
                        scope.documentHistories = [];
                        scope.messages = [];
                        angular.forEach(response.data, function (value, key) {
                            var docHistory = new DocumentHistory(value.id, value.documentId, value.actionEvent, value.account, value.date);
                            
                            var msg: string;
                            var date = new Date(docHistory.date + "");
                            var dateStr = filter('date')(date, 'yyyy-MM-dd HH:mm:ss');
                            switch (docHistory.actionEvent) {
                                case 1:
                                    msg = sce.trustAsHtml('Created by <a href="">' + docHistory.account.username + '</a> at ' + dateStr);
                                    break;
                                case 2:
                                    msg = sce.trustAsHtml('Updated by <a href="">' + docHistory.account.username + '</a> at ' + dateStr);
                                    break;
                                case 3:
                                    msg = sce.trustAsHtml('Deleted by <a href="">' + docHistory.account.username + '</a> at ' + dateStr);
                                    break;
                            }
                            scope.messages.push(msg);

                            scope.documentHistories.push(docHistory);
                        })
                    });
            }

            scope.getDocumentHistories();
        };
    }
}