(function (angular) {
    let myApp = angular.module('app');

    let actorDetailsController = function ($stateParams, actorService) {

        let $ctrl = this;
    
        actorService.getDetails($stateParams.id).then(function (actor) {
            $ctrl.actor = actor;
        });

        
    }


    actorDetailsController.$inject = ['$stateParams', 'actorService'];

    myApp.controller("actorDetailsController", actorDetailsController);


})(angular);