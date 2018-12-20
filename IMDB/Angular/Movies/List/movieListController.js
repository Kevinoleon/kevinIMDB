(function (angular) {
    let myApp = angular.module('app');
    
    let movieController = function (movieService) {
        let $ctrl = this;
        //traer todos los moviees
        function getAll() {
            movieService.getMovies().then(function (movies) {
                    $ctrl.movies = movies;
                });
        }                     
        getAll();
    }


    movieController.$inject = ['movieService'];

    myApp.controller("movieListController", movieController);  

      
})(angular);