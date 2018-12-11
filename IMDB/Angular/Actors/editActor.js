(function () {
    let myApp = angular.module('app');

    let editActor = {
        templateUrl: '/Angular/Actors/editActor.html',
        controller: 'editActorController',
    }
    myApp.component('editActor', editActor);
})(angular);