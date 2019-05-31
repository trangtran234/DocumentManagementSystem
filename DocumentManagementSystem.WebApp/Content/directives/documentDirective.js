var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentDirective = /** @class */ (function () {
        function DocumentDirective($http, $rootScope) {
            var _this = this;
            this.$http = $http;
            this.$rootScope = $rootScope;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/add-document.html';
            this.link = function (scope, element, attributes) {
                var rootScope = _this.$rootScope;
                scope.filesList = [];
                scope.files = [];
                _this.$http.get('/api/documenttypes/DocumentTypes')
                    .then(function (response) {
                    scope.documentTypes = response.data;
                });
                var parentID = null;
                scope.$on('rootScope:id', function (event, data) {
                    parentID = data;
                });
                //scope.$on('rootScope:treeviewId', function (event, data) {
                //    parentID = data;
                //});
                scope.changeFiles = function () {
                    var count = 0;
                    element.bind("change", function (changeEvent) {
                        if (count === 0) {
                            var fs = changeEvent.target.files;
                            for (var i = 0; i < fs.length; i++) {
                                var document = {};
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
                };
                scope.deleteDocumentInDialog = function (id) {
                    for (var i = 0; i < scope.filesList.length; i++) {
                        if (scope.filesList[i].id === id) {
                            scope.filesList.splice(i, 1);
                            scope.files.splice(i, 1);
                        }
                    }
                };
                scope.safeApply = function (fn) {
                    var phase = this.$root.$$phase;
                    if (phase == '$apply' || phase == '$digest') {
                        if (fn && (typeof (fn) === 'function')) {
                            fn();
                        }
                    }
                    else {
                        this.$apply(fn);
                    }
                };
                scope.uploadFiles = function () {
                    var formData = new FormData();
                    for (var i = 0; i < scope.files.length; i++) {
                        formData.append('file', scope.files[i]);
                    }
                    formData.append('parentID', parentID);
                    formData.append('typeID', JSON.stringify(scope.typesSelect.map(function (type) { return type.id; })));
                    if (parentID === null) {
                        alert("Please select folder.");
                    }
                    else {
                        _this.$http({
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
                                var document = {};
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
                            }, 1000);
                        }, function (response) {
                            console.log('Fail: ' + response);
                            scope.files = [];
                        });
                    }
                };
            };
        }
        DocumentDirective.Factory = function () {
            var directive = function ($http, $rootScope) { return new DocumentDirective($http, $rootScope); };
            directive.$inject = ['$http', '$rootScope'];
            return directive;
        };
        return DocumentDirective;
    }());
    rootApp.DocumentDirective = DocumentDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentDirective.js.map