(function () {
    let myApp = angular.module('app');

    let editCreateMovie = {
        templateUrl: '/Angular/Movies/EditCreate/editCreateMovie.html',
        controller: 'editCreateMovieController'
    }
    myApp.component('editCreateMovie', editCreateMovie);
})(angular);