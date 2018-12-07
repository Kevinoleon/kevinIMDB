(function () {
    let myApp = angular.module('MyFirstApp');

    letlistaActoresComp = {
        templateUrl: '~/Views/FrontEnd/ListaActores.html',
        controller: function () { },
        bindings: {
            Actores: '<'
        }
    }
    myApp.component('listaActores', listaActoresComp); 
})();