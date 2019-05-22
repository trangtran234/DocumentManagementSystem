var rootApp;
(function (rootApp) {
    'user strict';
    var TreeViewController = /** @class */ (function () {
        function TreeViewController($scope, $http) {
            var _this = this;
            this.$scope = $scope;
            this.$http = $http;
            this.getFolders = function () {
                _this.$http.get('http://localhost:55865/api/documents/Folders')
                    .then(function (response) {
                    _this.$scope.documents = response.data;
                });
            };
            this.getChildFolderOfTree = function (id) {
                _this.$http.get('/api/documents/FolderByFolderId/' + id)
                    .then(function (response) {
                    _this.$scope.childDocuments = response.data;
                });
            };
            //this.getFolders();
            //$scope.getChildFolderOfTree = this.getChildFolderOfTree;
            //$scope.onAddedNewFiles = () => {
            //    this.getChildFolderOfTree(3);
            //};
        }
        TreeViewController.$inject = ['$scope', '$http'];
        return TreeViewController;
    }());
    rootApp.TreeViewController = TreeViewController;
})(rootApp || (rootApp = {}));
//# sourceMappingURL=treeViewController.js.map