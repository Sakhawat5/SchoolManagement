'use strict';


// Declare app level module which depends on filters, and services
var app = angular.module('myApp', [
    'ngRoute',
    'ngResource',
    'myApp.filters',
    'myApp.services',
    'myApp.directives',
    'myApp.controllers',
    'myApp.factories'
])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/home', { templateUrl: 'partials/home.html', controller: 'HomeCtrl' });
        $routeProvider.when('/create', { templateUrl: 'partials/create.html', controller: 'CreateCtrl' });
        $routeProvider.when('/edit/:id', { templateUrl: 'partials/edit.html', controller: 'EditCtrl' });
        $routeProvider.when('/details/:id', { templateUrl: 'partials/details.html', controller: 'DetailsCtrl' });
        $routeProvider.when('/delete/:id', { templateUrl: 'partials/delete.html', controller: 'DeleteCtrl' });
        //$routeProvider.when('/edit/:id', { templateUrl: 'partials/edit.html', controller: 'EditCtrl' });
        //$routeProvider.when('/details/:id', { templateUrl: 'partials/details.html', controller: 'DetailsCtrl' });
        //$routeProvider.when('/delete/:id', { templateUrl: 'partials/delete.html', controller: 'DeleteCtrl' });
        $routeProvider.otherwise({ redirectTo: '/home' });
    }]);