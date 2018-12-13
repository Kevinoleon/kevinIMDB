(function (angular) {
    let myApp = angular.module('app');

    let createActorController = function (actorService, movieService) {

        let $ctrl = this;
        $ctrl.IsVisible = false;

        $ctrl.actorToCreate = { Roles: [] };

        function getMovies() {
                movieService.getMovies().then(function (movies) {
                    $ctrl.movies = movies;
                });
            }
        
        $ctrl.createActor = function () {
            debugger;
            actorService.postRequest($ctrl.actorToCreate).then(function (savedActor) {
                $ctrl.actorToCreate = $ctrl.savedActor;
            });
        };

        $ctrl.ShowHide = function () {
            $ctrl.IsVisible = !$ctrl.IsVisible;
        }
        

        getMovies();

        
        
    }


    createActorController.$inject = ['actorService', 'movieService'];

    myApp.controller("createActorController", createActorController);


})(angular);