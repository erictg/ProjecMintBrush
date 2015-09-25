var x = screen.width;
var imageur = document.getElementsByClassName("image");
imageur.width = (x / 2);

window.addEventListener('hashchange', function () {
    if (window.location.hash === '#/bookmark/1') {
        
    }
});

var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'pages/main.html', // URL FOR LOGIN PAGE
        controller: 'mainController'
    })
});

myApp.controller('mainController', ['$scope', '$location', '$log', function ($scope, $location, $log) {
    $log.info($location.path());
}]);