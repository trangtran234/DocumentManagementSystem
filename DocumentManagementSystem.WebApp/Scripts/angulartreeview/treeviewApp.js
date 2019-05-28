var app = angular.module('treeviewApp', ['angularTreeview']);
app.controller('treeviewController', ['$scope', '$http', function ($scope, $http) {
    $http.get('/api/documents/FolderStructure').then(function (response) {
        $scope.List = response.data;
    })
}])