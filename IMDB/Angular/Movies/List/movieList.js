(function () {
    let myApp = angular.module('app');

    let movieList = {
        templateUrl: '/Angular/Movies/List/movieList.html',
        controller: 'movieListController',
        bindings: {
            Moviees: '<'
        }
    }
    myApp.component('movieList', movieList); 
})(angular);