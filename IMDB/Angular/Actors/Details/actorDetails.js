(function () {
    let myApp = angular.module('app');

    let actorDetails = {
        templateUrl: '/Angular/Actors/Details/actorDetails.html',
        controller: 'actorDetailsController',
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('actorDetails', actorDetails);
})(angular);