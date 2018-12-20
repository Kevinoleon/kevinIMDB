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

        let movies = {
            url: '/movies',
            name: 'movies',
            template: '<movie-list></movie-list>'
        };

        let movieDetails = {
            url: '/movie/:id',
            name: 'movieDetail',
            template: '<movie-details-delete></movie-details-delete>'
        };

        let editMovie = {
            url: '/movie/edit/:id',
            name: 'editMovie',
            template: '<edit-create-movie></edit-create-movie>'
        };

        let createMovie = {
            url: '/movie/create',
            name: 'createMovie',
            template: '<edit-create-movie></edit-create-movie>'
        };

        let deleteMovie = {
            url: '/movie/delete/:id',
            name: 'deleteMovie',
            template: '<movie-details-delete><movie-header></movie-header><movie-movie></movie-movie></movie-details-delete>'
        };

        $urlRouterProvider.otherwise('/');
        $stateProvider.state(actors);
        $stateProvider.state(createActor);
        $stateProvider.state(actorDetails);
        $stateProvider.state(editActor);
        $stateProvider.state(deleteActor);
        $stateProvider.state(movies);
        $stateProvider.state(createMovie);
        $stateProvider.state(movieDetails);
        $stateProvider.state(editMovie);
        $stateProvider.state(deleteMovie);   
    
    });
})(angular);