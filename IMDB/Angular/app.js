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
        template: '<actor-details></actor-details>'
    };

    let editActor = {
        url: '/actor/edit/:id',
        name: 'editActor',
        template: '<edit-create-actor></edit-create-actor>'
    };

    let createActor = {
        url: '/actor/create',
        name: 'createActor',
        template: '<newedit-actor></newedit-actor>'
    };

    let deleteActor = {
        url: '/actor/delete/:id',
        name: 'deleteActor',
        template: '<delete-actor></delete-actor>'
    };

    $urlRouterProvider.otherwise('/');
    $stateProvider.state(actors);
    $stateProvider.state(createActor);
    $stateProvider.state(actorDetails);
    $stateProvider.state(editActor);
    $stateProvider.state(deleteActor);
    
    
    });
})(angular);