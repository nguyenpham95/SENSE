var myApp = angular.module("myApp", ['ngResource']);

myApp.controller("mainCrl", function ($scope, $http) {
    
    
    
    
    $http.get("WebService.asmx/getProject").then(function (response) {
        $scope.projects = response.data;
    });
    $http.get("WebService.asmx/getAllUser").then(function (response) {
        $scope.users = response.data;
    });
    $http.get("WebService.asmx/getAllLabhead").then(function (response) {
        $scope.labheads = response.data;
    });
});