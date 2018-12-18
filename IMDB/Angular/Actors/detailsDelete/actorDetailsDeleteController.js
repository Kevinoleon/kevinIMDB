(function (angular) {
    let myApp = angular.module('app');

    let actorDetailseleteController = function ($stateParams, actorService, $state) {

        let $ctrl = this;
        $ctrl.isDelete = true;

        if ($state.current.name != 'deleteActor') {
            $ctrl.pageTitle = "Details";
            $ctrl.isDelete = false;
            
        } else {
            $ctrl.pageTitle = "Are you sure you want to delete it?"
            
        }

        $ctrl.delete = function (id) {
            actorService.deleteActor(id).then(function (response) {
                alert(response);
            })
        }
    
        actorService.getDetails($stateParams.id).then(function (actor) {
            $ctrl.actor = actor;            
        })

        
    }


    actorDetailseleteController.$inject = ['$stateParams', 'actorService', '$state'];

    myApp.controller("actorDetailsDeleteController", actorDetailseleteController);


})(angular);