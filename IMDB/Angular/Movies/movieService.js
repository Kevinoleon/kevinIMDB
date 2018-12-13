(function () {
    let myApp = angular.module('app');

    let movieService = function ($http) {
        //esta url es igual para los metodos
        let urlMovieApi = "http://localhost:7130/api/MovieAPI/";
        
        return { getMovies, getDetails,deleteMovie, putRequest, postRequest};

        //metodo general que utilizaran los demas metodos.
        function getRequest(url) {
            let promise = $http({
                method: "get",
                url: url
            }).then(function (response) {
                return response.data;
            });
            return promise;
        };

        function getMovies() {
            return getRequest(urlMovieApi);
        };   

        function getDetails(id) {
            return getRequest(urlMovieApi+id)
        }

        function deleteMovie(id) {
            let promise = $http({
                method: "delete",
                url: urlMovieApi + id
            }).then(function (response) {
                return response.data;
            });
            return promise;
        };

        function putRequest(movie) {

            let movieRequest = movie;

            let promise = $http({
                method: "put",
                url: "http://localhost:7130/api/MovieAPI/" + movieRequest.Id,
                datatype: "json",
                data: JSON.stringify(movieRequest)
            }).then(function (response) {
                return response.data;
            });
            return promise;
        }; 
        function postRequest(movie) {

            let movieRequest = movie;

            let promise = $http({
                method: "post",
                url: "http://localhost:7130/api/MovieAPI/" + 0,
                datatype: "json",
                data: JSON.stringify(movieRequest)
            }).then(function (response) {
                return response.data;
            });
            return promise;
        };
    }

    movieService.$inject = ["$http"];
    myApp.factory('movieService', movieService);
})(angular);