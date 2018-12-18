(function (angular) {
var myApp = angular.module("app", ['ui.router']);

myApp.config(function ($stateProvider, $urlRouterProvider) {
    let actors = {
        url: '/actors',
        name: 'actors',
        template: '<actor-list></actor-list>'
    };

    let actorDetails = {
        url: '/actor/:id',
        name: 'actorDetail',
        template: '<actor-details-delete></actor-details-delete>'
    };

    let editActor = {
        url: '/actor/edit/:id',
        name: 'editActor',
        template: '<edit-create-actor></edit-create-actor>'
    };

    let createActor = {
        url: '/actor/create',
        name: 'createActor',
        template: '<edit-create-actor></edit-create-actor>'
    };

    let deleteActor = {
        url: '/actor/delete/:id',
        name: 'deleteActor',
        template: '<actor-details-delete><actor-header></actor-header><actor-movie></actor-movie></actor-details-delete>'
    };

    $urlRouterProvider.otherwise('/');
    $stateProvider.state(actors);
    $stateProvider.state(createActor);
    $stateProvider.state(actorDetails);
    $stateProvider.state(editActor);
    $stateProvider.state(deleteActor);
    
    
    });
})(angular);