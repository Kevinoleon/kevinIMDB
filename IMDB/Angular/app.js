(function (angular) {
var myApp = angular.module("app", ['ui.router']);

myApp.config(function ($stateProvider, $urlRouterProvider) {
    let actors = {
        url: '/actors',
        name: 'actors',
        template: '<lista-actores></lista-actores>'
    };

    let actorDetails = {
        url: '/actor/:id',
        name: 'actorDetail',
        template: '<actor-details></actor-details>'
    };

    let editActor = {
        url: '/actor/edit/:id',
        name: 'editActor',
        template: '<edit-actor></edit-actor>'
    };

    $urlRouterProvider.otherwise('/');
    $stateProvider.state(actors);
    $stateProvider.state(actorDetails);
    $stateProvider.state(editActor);
    });
})(angular);