(function (angular) {
    let myApp = angular.module('app');
    
    let actorController = function ($scope, actorService) {
        let $ctrl = this;
        //traer todos los actores
        function getAll() {
            actorService.getActors().then(function (actors) {
                    $scope.actors = actors;
                });
        }

        $ctrl.deleteActor= function deleteActor(id) {
            actorService.deleteActor(id).then(function (response) {
                alert(response);
            });
        }



        getAll();
    }


    actorController.$inject = ['$scope', 'actorService'];

    myApp.controller("actorController", actorController);  

      
})(angular);