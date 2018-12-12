(function (angular) {
    let myApp = angular.module('app');

    let createActorController = function (actorService) {

        let $ctrl = this;
        
        $ctrl.createActor = function createActor(actorToPost) {
            actorService.postRequest(actorToPost).then(function (response) {
                alert(response);
            });
        };

        
    }


    createActorController.$inject = ['actorService'];

    myApp.controller("createActorController", createActorController);


})(angular);