(function () {
    'use strict';

    var angularApp = angular.module('app', []);

    angularApp.controller('GreetingController', ['$scope', function ($scope) {
        $scope.greeting = 'Hola!';
    }]);
})();