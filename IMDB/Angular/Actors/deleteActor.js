(function () {
    let myApp = angular.module('app');

    let deleteActor = {
        templateUrl: '/Angular/Actors/deleteActor.html',
        controller: 'deleteActorController',
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('deleteActor', deleteActor);
})(angular);