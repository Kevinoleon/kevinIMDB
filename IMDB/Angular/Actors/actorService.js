(function () {
    let myApp = angular.module('app');

    let actorService = function ($http) {
        //esta url es igual para los metodos
        let urlActorApi = "http://localhost:7130/api/ActorAPI/";
        
        return { getActors, getDetails, deleteActor, putRequest, postRequest };

        function processActor(actor) {
            if (actor.DateOfBirth) {
                movie.DateOfBirth = new Date(actor.DateOfBirth);
            }
        }

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

        function getActors() {
            return getRequest(urlActorApi);
        };   

        function getDetails(id) {
            return getRequest(urlActorApi+id)
        }

        function deleteActor(id) {
            let promise = $http({
                method: "delete",
                url: urlActorApi + id
            }).then(function (response) {
                return response.data;
            });
            return promise;
        };

        function putRequest(actor) {

            let actorRequest = actor;

            let promise = $http({
                method: "put",
                url: urlActorApi + actorRequest.Id,
                datatype: "json",
                data: JSON.stringify(actorRequest)
            }).then(function (response) {
                return response.data;
            });
            return promise;
        }; 
        function postRequest(actor) {

            let actorRequest = actor;

            let promise = $http({
                method: "post",
                url: urlActorApi + 0,
                datatype: "json",
                data: JSON.stringify(actorRequest)
            }).then(function (response) {
                return response.data;
            });
            return promise;
        };
    }

    actorService.$inject = ["$http"];
    myApp.factory('actorService', actorService);
})(angular);