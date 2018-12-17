(function (angular) {
    let myApp = angular.module('app');

    let editCreateActorController = function ($q, $stateParams, actorService, movieService) {

        let $ctrl = this;
        $ctrl.IsVisible = false;
        $ctrl.actorToCreate = {};

        $ctrl.saveActor = function () {
            $ctrl.saving = true;
            var savePromise = $ctrl.actor.Id
                ? actorService.putRequest($ctrl.actor)
                : actorService.postRequest($ctrl.actor);
            savePromise.then(function (actor) {
                $ctrl.actor = actor;
            }).finally(function () {
                $ctrl.saving = false;
                alert("actor saved!");
            });
        }

        function initialize() {
            $ctrl.initializing = true;
            $q.all({
                movies: movieService.getMovies(),
                actor: $stateParams.id ? actorService.getDetails($stateParams.id) : $q.when({ Roles: [] })
            }).then(function (results) {
                $ctrl.actor = results.actor;
                $ctrl.actor.DateOfBirth = new Date($ctrl.actor.DateOfBirth);
                $ctrl.movies = results.movies;
            }).finally(function () {
                 $ctrl.initializing = false;
            });
        }

        initialize();
    }


    editCreateActorController.$inject = ['$q', '$stateParams', 'actorService', 'movieService'];

    myApp.controller("editCreateActorController", editCreateActorController);


})(angular);