(function () {
    let myApp = angular.module('app');

    let actorService = function ($http) {
        //esta url es igual para los metodos
        let urlActorApi = "http://localhost:7130/api/ActorAPI/";
        
        return { getActors, getDetails,deleteActor, putRequest};

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

        function putRequest(id, actor) {

            let actorRequest = actor;

            let promise = $http({
                method: "put",
                url: "http://localhost:7130/api/ActorAPI/" + id,
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