(function () {
    let myApp = angular.module('app');

    let listaActores = {
        templateUrl: '/Angular/Actors/listaActores.html',
        controller: 'actorController',
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('listaActores', listaActores); 
})(angular);