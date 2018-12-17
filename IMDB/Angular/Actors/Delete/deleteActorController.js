(function (angular) {
    let myApp = angular.module('app');

    let deleteActorController = function ($stateParams, actorService) {

        let $ctrl = this;
                
        actorService.getDetails($stateParams.id).then(function (actor) {
            $ctrl.actor = actor;
        });

        $ctrl.deleteActor = function deleteActor(id) {
            actorService.deleteActor(id).then(function (response) {
                alert(response);
            });
        }

        
    }


    deleteActorController.$inject = ['$stateParams', 'actorService'];

    myApp.controller("deleteActorController", deleteActorController);


})(angular);