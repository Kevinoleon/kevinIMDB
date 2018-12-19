(function () {
    let myApp = angular.module('app');

    let actorDetailsDelete = {
        templateUrl: '/Angular/Actors/DetailsDelete/actorDetailsDelete.html',
        controller: 'actorDetailsDeleteController'        
    }
    myApp.component('actorDetailsDelete', actorDetailsDelete);
})(angular);