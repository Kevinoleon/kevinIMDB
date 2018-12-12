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

    let createActor = {
        url: '/actor/create',
        name: 'createActor',
        template: '<create-actor></create-actor>'
    };

    $urlRouterProvider.otherwise('/');
    $stateProvider.state(actors);
    $stateProvider.state(createActor);
    $stateProvider.state(actorDetails);
    $stateProvider.state(editActor);
    
    
    });
})(angular);