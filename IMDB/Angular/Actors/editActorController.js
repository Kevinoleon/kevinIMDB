(function (angular) {
    let myApp = angular.module('app');

    let editActorController = function ($scope, $stateParams, actorService) {

        let $ctrl = this;
        actorService.getDetails($stateParams.id).then(function (actor) {

            
            
            $ctrl.actorToEdit = actor;
            $ctrl.actorToEdit.DateOfBirth = new Date(actor.DateOfBirth);

        });

        $ctrl.editActor = function editActor(actorToPut) {
            actorService.putRequest(actorToPut).then(function (response) {
                alert(response);
            });
        }

        
    }


    editActorController.$inject = ['$scope', '$stateParams', 'actorService'];

    myApp.controller("editActorController", editActorController);


})(angular);