(function (angular) {
    let myApp = angular.module('app');

    let detailsActorController = function ($scope, $stateParams, actorService) {


        
        actorService.getDetails($stateParams.id).then(function (actor) {
            $scope.actor = actor;
        });

        
    }


    detailsActorController.$inject = ['$scope', '$stateParams', 'actorService'];

    myApp.controller("detailsActorController", detailsActorController);


})(angular);