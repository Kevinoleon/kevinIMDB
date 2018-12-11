(function (angular) {
    let myApp = angular.module('app');

    let editActorController = function ($scope, $stateParams, actorService) {

        let $ctrl = this;
        actorService.getDetails($stateParams.id).then(function (actor) {
            
            $ctrl.actorToEdit = actor;
            $ctrl.actorToEdit.DateOfBirth = new Date(actor.DateOfBirth);

        });

        ////envía el actor a la pantalla de edición
        //function editActorController() {
        //    actorService.                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ($stateParams.id).then(function (actor) {
        //        $scope.actor = actor;
        //    });
        //}

        
    }


    editActorController.$inject = ['$scope', '$stateParams', 'actorService'];

    myApp.controller("editActorController", editActorController);


})(angular);