(function () {
    let myApp = angular.module('app');

    let movieDetailsDelete = {
        templateUrl: '/Angular/Movies/DetailsDelete/movieDetailsDelete.html',
        controller: 'movieDetailsDeleteController'        
    }
    myApp.component('movieDetailsDelete', movieDetailsDelete);
})(angular);