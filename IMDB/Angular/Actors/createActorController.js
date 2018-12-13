(function (angular) {
    let myApp = angular.module('app');

    let createActorController = function (actorService, movieService) {

        let $ctrl = this;
        $ctrl.IsVisible = false;
        function getMovies() {
                movieService.getMovies().then(function (movies) {
                    $ctrl.movies = movies;
                });
            }
        
        $ctrl.createActor = function(actorToPost) {
            actorToPost.Roles = [];
            actorToPost.Roles.push($ctrl.Role);
            actorService.postRequest(actorToPost).then(function (response) {
                alert(response);
            });
        };

        $ctrl.ShowHide = function () {
            if ($ctrl.IsVisible!= true) {
                $ctrl.IsVisible  = true;
            } else {
                $ctrl.isVisible = false;
            }           
        }
        

        getMovies();

        
        
    }


    createActorController.$inject = ['actorService', 'movieService'];

    myApp.controller("createActorController", createActorController);


})(angular);