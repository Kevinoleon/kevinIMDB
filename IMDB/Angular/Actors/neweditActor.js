(function () {
    let myApp = angular.module('app');

    let editActor = {
        templateUrl: '/Angular/Actors/neweditActor.html',
        controller: 'neweditActorController',
    }
    myApp.component('neweditActor', editActor);
})(angular);