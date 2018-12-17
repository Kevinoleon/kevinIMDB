(function () {
    let myApp = angular.module('app');

    let actorList = {
        templateUrl: '/Angular/Actors/List/actorList.html',
        controller: 'actorListController',
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('actorList', actorList); 
})(angular);