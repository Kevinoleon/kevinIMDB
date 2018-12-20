(function (angular) {
    let myApp = angular.module('app');

    let movieDetailDeleteController = function ($stateParams, movieService, $state) {

        let $ctrl = this;
        $ctrl.isDelete = true;

        if ($state.current.name != 'deleteMovie') {
            $ctrl.pageTitle = "Details";
            $ctrl.isDelete = false;

        } else {
            $ctrl.pageTitle = "Are you sure you want to delete it?"

        }

        $ctrl.delete = function (id) {
            movieService.deleteMovie(id).then(function (response) {
                alert(response);
            })
        }

        movieService.getDetails($stateParams.id).then(function (movie) {
            $ctrl.movie = movie;
        })


    }


    movieDetailDeleteController.$inject = ['$stateParams', 'movieService', '$state'];

    myApp.controller("movieDetailsDeleteController", movieDetailDeleteController);


})(angular);