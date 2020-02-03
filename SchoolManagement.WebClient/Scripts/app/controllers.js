'use strict';

//app.factory('Student', ['$resource', function ($resource) {
//    var resource = $resource('http://localhost:49557//api//Student');
//    return resource;
//}
//]);

angular.module('myApp.factories', []).factory('Student', ['$resource',
    function ($resource) {
        var resource = $resource('http://localhost:51518/api/Student', {}, { get: { method: 'GET', isArray: true } });
        return resource;
    }]);


angular.module('myApp.controllers', [])
    .controller('HomeCtrl', ['$scope', 'Student', function ($scope, Student) {
        $scope.name = "List of student.";

        $scope.students = [];

        Student.get(function (resource) {
            $scope.students = resource;
        });

        //$scope.students.push({ Id: 1, Name: 'Tiger', Address: 'Africa' });
        //$scope.students.push({ Id: 2, Name: 'Lion', Address: 'India' });
        //$scope.students.push({ Id: 3, Name: 'Ziraf', Address: 'Napal' });

    }])
    .controller('CreateCtrl', ['$scope', 'Student', function ($scope, Student) {
        $scope.title = "Create student";
        $scope.name = '';
        $scope.phone = '';
        $scope.address = '';
        $scope.departmentId = '';
        $scope.courseId = '';

        $scope.save = function () {
            Student.save({ Name: $scope.name, Phone: $scope.phone, Address: $scope.address, DepartmentId: $scope.departmentId, CourseId: $scope.courseId }, function (resource) {
                console.log(resource);

                if (resource) {
                    $scope.notification = "Successfully Save";
                    $scope.name = '';
                    $scope.phone = '';
                    $scope.address = '';
                    $scope.departmentId = '';
                    $scope.courseId = '';
                } else {
                    $scope.notification = "Successfully not save";
                }
            });
        };
    }])
    .controller('EditCtrl', ['$scope', 'Student', '$routeParams', '$location', function ($scope, Student, $routeParams, $location) {
        $scope.title = "Edit student document.";
        var requestId = $routeParams.id;

        Student.get({ request: JSON.stringify(requestId) }, function (response) {
            console.log(response);
            $scope.student = response[0];
        });

        $scope.save = function () {
            Student.save($scope.student, function (response) {
                //console.log(response);
                if (response) {
                    $scope.student = {};
                    $location.path('/home');
                } else {
                    $scope.message = "Failed! Try Again!";
                }
            });
        };
    }])
    .controller('DetailsCtrl', ['$scope', 'Student', '$routeParams', function ($scope, Student, $routeParams) {
        $scope.title = "Detais of student.";
        var requestId = $routeParams.id;
        $scope.student = '';
        Student.get({ request: JSON.stringify(requestId) }, function (response) {
            console.log(response);
            $scope.student = response[0];
        });
    }])
    .controller('DeleteCtrl', ['$scope', 'Student', '$routeParams', '$location', function ($scope, Student, $routeParams, $location) {
        $scope.title = "Delete document of student.";
        var requestId = $routeParams.id;

        Student.get({ request: JSON.stringify(requestId) }, function (response) {
            console.log(response);
            $scope.student = response[0];
        });

        $scope.delete = function () {
            Student.delete({ request: JSON.stringify(requestId) }, function (response) {
                console.log(response);
                if (response) {
                    $scope.student = {};
                    $location.path('/home');
                } else {
                    $scope.message = "Failed! Try Again!";
                }
            });
        };
    }]);
