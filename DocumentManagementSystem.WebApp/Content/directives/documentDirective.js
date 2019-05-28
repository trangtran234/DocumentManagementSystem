var rootApp;
(function (rootApp) {
    'use strict';
    var DocumentDirective = /** @class */ (function () {
        function DocumentDirective($http) {
            var _this = this;
            this.$http = $http;
            this.restrict = "E";
            this.templateUrl = '/Content/directives/add-document.html';
            this.link = function (scope, element, attributes) {
                scope.filesList = [];
                scope.files = [];
                element.bind("change", function (changeEvent) {
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
                });
                scope.deleteDocumentInDialog = function (id) {
                    console.log("Document Id " + id);
                    for (var i = 0; i < scope.filesList.length; i++) {
                        if (scope.filesList[i].id === id) {
                            scope.filesList.splice(i, 1);
                            scope.files.splice(i, 1);
                        }
                    }
                };
                scope.uploadFiles = function () {
                    for (var i = 0; i < scope.filesList.length; i++) {
                        if (scope.filesList[i].documentSize > 20480) {
                            alert("Maximum size 20MB: " + scope.filesList[i].documentName);
                            return;
                        }
                    }
                    var formData = new FormData();
                    for (var i = 0; i < scope.files.length; i++) {
                        formData.append('file', scope.files[i]);
                    }
                    _this.$http({
                        url: '/api/upload/uploadDocuments',
                        method: 'POST',
                        data: formData,
                        transformRequest: angular.identity,
                        headers: {
                            'Content-Type': undefined
                        },
                    }).then(function (response) {
                        console.log('Success: ' + response);
                        scope.onSave();
                    }, function (response) {
                        console.log('Fail: ' + response);
                    });
                };
            };
        }
        DocumentDirective.Factory = function () {
            var directive = function ($http) { return new DocumentDirective($http); };
            directive.$inject = ['$http'];
            return directive;
        };
        DocumentDirective.$inject = ['$http'];
        return DocumentDirective;
    }());
    rootApp.DocumentDirective = DocumentDirective;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=documentDirective.js.map