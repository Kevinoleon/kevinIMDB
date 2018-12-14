(function (angular) {
    let myApp = angular.module('app');

    let editActorController = function ($scope, $stateParams, actorService, movieService) {

        let $ctrl = this;
        $ctrl.IsVisible = false;
        $ctrl.actorToCreate = {};

        actorService.getDetails($stateParams.id).then(function (actor) {          
            
            $ctrl.actorToEdit = actor;
            $ctrl.actorToEdit.DateOfBirth = new Date(actor.DateOfBirth);

        });

        function getMovies() {
            movieService.getMovies().then(function (movies) {
                $ctrl.movies = movies;
            });
        }

        $ctrl.editActor = function editActor(actorToPut) {
            actorService.putRequest(actorToPut).then(function (response) {
                alert(response);
            });
        }

        getMovies();
        
    }


    editActorController.$inject = ['$scope', '$stateParams', 'actorService', 'movieService'];

    myApp.controller("editActorController", editActorController);


})(angular);