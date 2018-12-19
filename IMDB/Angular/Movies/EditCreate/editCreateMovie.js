(function () {
    let myApp = angular.module('app');

    let editCreateActor = {
        templateUrl: '/Angular/Actors/EditCreate/editCreateActor.html',
        controller: 'editCreateActorController'
    }
    myApp.component('editCreateActor', editCreateActor);
})(angular);