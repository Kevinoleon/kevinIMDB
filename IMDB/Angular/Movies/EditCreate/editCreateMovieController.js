(function (angular) {
    let myApp = angular.module('app');

    let editCreateMovieController = function ($q, $stateParams, movieService, actorService) {

        let $ctrl = this;
        $ctrl.IsVisible = false;
        $ctrl.movieToCreate = {};

        $ctrl.saveMovie = function () {
            $ctrl.saving = true;
            var savePromise = $ctrl.movie.Id
                ? movieService.putRequest($ctrl.movie)
                : movieService.postRequest($ctrl.movie);
            savePromise.then(function (movie) {
                $ctrl.movie = movie;
            }).finally(function () {
                $ctrl.saving = false;
                alert("movie saved!");
            });
        }

        function initialize() {
            $ctrl.initializing = true;
            $q.all({
                actors: actorService.getActors(),
                movie: $stateParams.id ? movieService.getDetails($stateParams.id) : $q.when({ Characters: [] })
            }).then(function (results) {
                $ctrl.movie = results.movie;
                $ctrl.movie.DateOfBirth = new Date($ctrl.movie.DateOfBirth);
                $ctrl.actors = results.actors;
            }).finally(function () {
                 $ctrl.initializing = false;
            });
        }

        initialize();
    }


    editCreateMovieController.$inject = ['$q', '$stateParams', 'movieService', 'actorService'];

    myApp.controller("editCreateMovieController", editCreateMovieController);


})(angular);