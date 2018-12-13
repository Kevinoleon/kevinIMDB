(function () {
    let myApp = angular.module('app');

    let actorRoleComp = {
        templateUrl: '/Angular/Actors/actorRole.html',
        controller: 'actorRoleController',
        bindings: {
            dato: '<',
            addnewRole: '&',
            removeActorRole: '&'
        }
    }
    myApp.component('actorRole', actorRoleComp);
})(angular);