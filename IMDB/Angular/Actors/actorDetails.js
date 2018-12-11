(function () {
    let myApp = angular.module('app');

    let actorDetails = {
        templateUrl: '/Angular/Actors/actorDetails.html',
        controller: 'detailsActorController',
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('actorDetails', actorDetails);
})(angular);