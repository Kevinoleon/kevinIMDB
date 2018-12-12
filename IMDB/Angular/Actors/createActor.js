(function () {
    let myApp = angular.module('app');

    let createActor = {
        templateUrl: '/Angular/Actors/createActor.html',
        controller: 'createActorController',
    }
    myApp.component('createActor', createActor);
})(angular);