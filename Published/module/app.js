var myApp = angular.module("myApp", ['ngResource', 'ngRoute']);

myApp.controller("mainCrl", function ($scope,$http) {
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

myApp.controller("projCrl", function ($scope, $http) {
    $http.get("WebService.asmx/getProject").then(function (response) {
        $scope.projects = response.data;
    });

});

myApp.controller('projDetailCrl', ['$scope', '$http', '$routeParams',
  function ($scope, $http, $routeParams) {
      $scope.selectedProjID = $routeParams.ID;
      var projID = $routeParams.ID;

      $http.get("WebService.asmx/getProjectDetail", { params: { "proID": projID } })
        .then(function (response) {
            $scope.proj = response.data;
            console.log(response.data);
            $http.get("WebService.asmx/getUserByID", { params: { "userID": $scope.proj[0].authorID } })
                .then(function (response) {
                    $scope.selectedUser = response.data;
                    console.log(response.data);
        });
        });

      $http.get("WebService.asmx/getUploadByID", { params: { "proID": projID } })
        .then(function (response) {
            $scope.selectedUpload = response.data;
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

  }]);

myApp.controller("profCrl", function ($scope, $http) {
    $http.get("WebService.asmx/getAllLabhead").then(function (response) {
        $scope.labheads = response.data;
    });

    $http.get("WebService.asmx/getAllUser").then(function (response) {
        $scope.users = response.data;
    });
});

myApp.controller('profDetailCrl', ['$scope', '$http', '$routeParams',
  function ($scope, $http, $routeParams) {
      $scope.selectedProfLink = $routeParams.ID;
      var profLink = $routeParams.ID;

      $http.get("WebService.asmx/getUserByLink", { params: { "userLink": profLink } })
        .then(function (response) {
            $scope.profile = response.data;
            var profile_bin = response.data;
            console.log(response.data);
            $http.get("WebService.asmx/getProjectByAuthorLink", { params: { "authorLink": $scope.selectedProfLink } })
                .then(function (response) {
                    $scope.selectedProject = response.data;
                    console.log(response.data);
                });
        });

      $http.get("WebService.asmx/getUploadByAuthorLink", { params: { "authorLink": $scope.selectedProfLink } })
        .then(function (response) {
            $scope.selectedUpload = response.data;
            console.log(response.data);
        });
      $http.get("WebService.asmx/getAllUser").then(function (response) {
          $scope.users = response.data;
      });
      $http.get("WebService.asmx/getAllLabhead").then(function (response) {
          $scope.labheads = response.data;
      });
      
      
  }]);

myApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/index', {
            templateUrl: 'partials/indexView.html',
            controller: 'mainCrl'
        }).
        when('/projects', {
            templateUrl: 'partials/projectView.html',
            controller: 'projCrl'
        }).
        when('/projects/:ID', {
            templateUrl: 'partials/projectDetail.html',
            controller: 'projDetailCrl'
        }).
        when('/profiles', {
              templateUrl: 'partials/profileView.html',
              controller: 'profCrl'
          }).
        when('/profiles/:ID', {
            templateUrl: 'partials/profileDetail.html',
            controller: 'profDetailCrl'
        }).
        when('/facilities', {
            templateUrl: 'partials/facilityView.html',
            controller: 'faciCrl'
        }).
        otherwise({
            redirectTo: '/index'
        });
  }]);

myApp.controller("faciCrl", function ($scope, $http) {
    $http.get("WebService.asmx/getAllFaci").then(function (response) {
        $scope.facis = response.data;
    });

    
});

myApp.filter("sanitize", ['$sce', function ($sce) {
    return function (htmlCode) {
        return $sce.trustAsHtml(htmlCode);
    }
}]);