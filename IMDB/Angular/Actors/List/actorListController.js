(function (angular) {
    let myApp = angular.module('app');
    
    let actorController = function (actorService) {
        let $ctrl = this;
        //traer todos los actores
        function getAll() {
            actorService.getActors().then(function (actors) {
                    $ctrl.actors = actors;
                });
        }                     
        getAll();
    }


    actorController.$inject = ['actorService'];

    myApp.controller("actorListController", actorController);  

      
})(angular);