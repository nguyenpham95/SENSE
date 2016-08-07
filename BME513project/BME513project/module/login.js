var loginApp = angular.module("loginApp", ['ngResource', 'ngRoute'])
.controller('mainCrl', ['$scope', '$http', '$window', 'fileUpload', function ($scope, $http, $window, fileUpload) {
    ///////////////////////
    // Files upload function here
    ///////////////////////

    
    $scope.uploadFile = function () {
        var file = $scope.myFile;
        console.log('file is ');
        console.dir(file);
        var uploadUrl = "userStuff/upload";
        fileUpload.uploadFileToUrl(file, uploadUrl);
    };
    


    ///////////////////////////
    /////////end of idle upload
    ///////////////////////////



    $scope.getDatetime = new Date();
    $scope.projectNum = 5;
    $scope.announceNum = 3;
    $http.get("WebService.asmx/getAnnouncement").then(function (response) {
        $scope.announces = response.data;
    });
    $http.get("WebService.asmx/getNoti").then(function (response) {
        $scope.notis = [];
        var i = 0;
        while (i <= 3) {
            $scope.notis[i] = response.data[i];
            i = i + 1;
        }
    });
    $http.get("WebService.asmx/getUpload").then(function (response) {
        $scope.uploads = response.data;
    });
    $http.get("WebService.asmx/getUploadByAuthorID", { params: { "authorID": angular.element(document.querySelector('#txtID')).text() } })
        .then(function (response) {
            $scope.selectedUploads = response.data;
            console.log(response.data);
        });
    $http.get("WebService.asmx/getProject").then(function (response) {
        $scope.projects = response.data;
    });
    $http.get("WebService.asmx/getAllUser").then(function (response) {
        $scope.users = response.data;
    });
    $http.get("WebService.asmx/getAllLabhead").then(function (response) {
        $scope.labheads = response.data;
    });

    //
    // Finally log out function is here
    //


    $scope.perform_Logout = function () {

        $scope.authen = false;
        $window.location.href = 'index.html';

    };
    $scope.perform_Login = function ($scope, $http) {
        $http.get("WebService.asmx/checkLogin", { params: { "id": $scope.id, "pass": $scope.pass } }).then(function (response) {
            $scope.result = response.data;
            var trial = $scope.result[0].result;
            if (trial == "success") {
                $scope.authen = true;
                $scope.notauthen = false;
            }
            else {
                $scope.authen = false;
                $scope.notauthen = true;
            }
        });
    };

    var myEl = angular.element(document.querySelector('#txtID'));
    $scope.id = myEl.text();
}]);

//
//   Rounter
//





loginApp.filter("sanitize", ['$sce', function ($sce) {
    return function (htmlCode) {
        return $sce.trustAsHtml(htmlCode);
    }
}]);


loginApp.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);



loginApp.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function () {
            console.log("success");
        })
        .error(function () {
            console.log("error");
        });
    }
}]);