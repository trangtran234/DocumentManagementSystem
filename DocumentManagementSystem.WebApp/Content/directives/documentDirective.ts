module rootApp {
    'use strict';

    import Document = rootApp.model.Document;
    import DocumentType = rootApp.model.DocumentType;

    export interface IUploadDocumentScope extends ng.IScope {
        filesList: Array<Document>;
        files: any;
        documentTypes: Array<DocumentType>;
        typesSelect: Array<DocumentType>;
        uploadFiles: () => void;
        deleteDocumentInDialog: (id) => void;
        onSave: () => void;
        changeFiles: () => void;
        safeApply: (any) => void; 
        getDocumentTypes: () => void;
    }
    export class DocumentDirective implements ng.IDirective {
        public restrict: string = "E";
        public templateUrl: string = '/Content/directives/add-document.html';
        public scope: {
            onSave: '&';
        }

        constructor(private $http: ng.IHttpService, private $rootScope: ng.IRootScopeService) { }

        public static Factory(): ng.IDirectiveFactory {
            const directive = ($http: ng.IHttpService, $rootScope: ng.IRootScopeService) => new DocumentDirective($http, $rootScope);
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        }

        public link: ng.IDirectiveLinkFn = (
            scope: IUploadDocumentScope,
            element: ng.IAugmentedJQuery,
            attributes: ng.IAttributes
        ) => {

            var rootScope = this.$rootScope;
            scope.filesList = [];
            scope.files = [];            

            this.$http.get<DocumentType[]>('/api/documenttypes/DocumentTypes')
                .then((response: ng.IHttpPromiseCallbackArg<DocumentType[]>) => {
                    scope.documentTypes = response.data;
                });

            var parentID = null;
            scope.$on('rootScope:id', function (event, data) {
                parentID = data;
            });
            scope.$on('listing:Id', function (event, data) {
                parentID = data;
            });

            $('.modal').on('hidden.bs.modal', function (e) {
                scope.safeApply(function () {

                    scope.filesList = [];
                    scope.files = [];
                    scope.typesSelect = [];
                });
            });

            scope.changeFiles = () => { 

                var count = 0;
                element.bind("change", function (changeEvent: Event) {
                   
                    if (count === 0) {
                        let fs = (<HTMLInputElement>changeEvent.target).files;

                        for (var i = 0; i < fs.length; i++) {

                            var document = new Document();

                            document.id = Math.floor((Math.random() * 100) + 1);
                            document.documentName = fs[i].name;
                            document.documentSize = fs[i].size;
                            document.documentType = fs[i].type;
                            document.statusUpload = -1;

                            scope.filesList.push(document);
                            scope.files.push(fs[i]);
                        }
                        scope.$apply();
                        count++;
                    }

                });

            }
            scope.deleteDocumentInDialog = (id) => {

                for (var i = 0; i < scope.filesList.length; i++) {
                    if (scope.filesList[i].id === id) {
                        scope.filesList.splice(i, 1);
                        scope.files.splice(i, 1);
                    }
                }
            }

            scope.safeApply = function (fn) {
                var phase = this.$root.$$phase;
                if (phase == '$apply' || phase == '$digest') {
                    if (fn && (typeof (fn) === 'function')) {
                        fn();
                    }
                } else {
                    this.$apply(fn);
                }
            };

            scope.uploadFiles = () => {               
                
                var formData = new FormData();
                for (var i = 0; i < scope.files.length; i++) {
                    formData.append('file', scope.files[i]);                   
                }
                formData.append('parentID', parentID);

                formData.append('typeID', JSON.stringify(scope.typesSelect.map((type) => { return type.id; })));
                

                if (parentID === null) {
                    alert("Please select folder.");
                }
                else {
                    this.$http({
                        url: '/api/upload/uploadDocuments',
                        method: 'POST',
                        data: formData,
                        transformRequest: angular.identity,
                        headers: {
                            'Content-Type': undefined
                        },
                    }).then(function (response) {
                        rootScope.$broadcast('uploadSuccess', parentID);

                        scope.filesList = [];
                        angular.forEach(response.data, function (value, key) {
                            var document = new Document();

                            document.id = value.id;
                            document.documentName = value.documentName + '.' + value.documentType;
                            document.documentSize = value.documentSize;
                            document.statusUpload = 0;

                            scope.filesList.push(document);
                        });

                        scope.$apply;

                        setTimeout(function () {

                            scope.safeApply(function () {

                                scope.filesList = [];
                                scope.files = [];
                                scope.typesSelect = [];
                            });

                            $('#addDocument').modal('hide');
                        }, 1000)

                    },
                        function (response) {
                            console.log('Fail: ' + response);
                            scope.files = [];
                        });
                } 
            }
        }
    }
}