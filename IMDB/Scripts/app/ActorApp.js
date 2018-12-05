//let myApp = angular.module('imdb', []);

//let actorCtrl = function () {
//    this.unTexto = "Hello world from angular!";
//}
//myApp.controller('actorCtrl', actorCtrl);

//console.log("a ver cual es la joda catrejijeptas");

var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {    
    $scope.formTitle = 'Add new Actor';
    $scope.PostActor = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Actor = {};
            $scope.Actor.Name = $scope.Name;
            $scope.Actor.Nationality = $scope.Nationality;
            $scope.Actor.DateOfBirth = $scope.DateOfBirth;
            $scope.Actor.Roles = $scope.Roles;
            $http({
                method: "post",
                url: "http://localhost:7130/api/ActorAPI/",
                datatype: "json",
                data: JSON.stringify($scope.Actor)
            }).then(function (response) {
                alert("Actor Created");
                $scope.GetAllData();
                $scope.Name = "";
                $scope.Nationality = "";
                $scope.DateOfBirth = "";
                $scope.Roles = "";
            })
        } else {
            $scope.Actor = {};
            $scope.Actor.Id = $scope.Id;
            $scope.Actor.Name = $scope.Name;
            $scope.Actor.Nationality = $scope.Nationality;
            $scope.Actor.DateOfBirth = $scope.DateOfBirth;
            $scope.Actor.Roles = $scope.Roles;
            $http({
                method: "put",
                url: "http://localhost:7130/api/ActorAPI/" + $scope.Actor.Id,
                datatype: "json",
                data: JSON.stringify($scope.Actor)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Name = "";
                $scope.Nationality = "";
                $scope.DateOfBirth = "";
                $scope.Roles = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Actor";
            })
            
        }
    }
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:7130/api/ActorAPI/"
        }).then(function (response) {
            $scope.actors = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.Detail = function (id) {
        $http({
            method: "get",
            url: "http://localhost:7130/api/ActorAPI/" + id,
            datatype: "json",
            //data: JSON.stringify(response)
        }).then(function (response) {
            var modal = document.getElementById("modal");
            modal.innerHTML = "Name: "+ response.data.Name + "<br/>" +
                                "Nationality: "+response.data.Nationality + "<br/>" +
                                "Date of birth: "+response.data.DateOfBirth + "<br/>" +
                                    "Roles:<br/>" +
                                    JSON.stringify(response.data.Roles);
            
            $scope.GetAllData();
        })
    };
    $scope.Delete = function (id) {
        $http({
            method: "delete",
            url: "http://localhost:7130/api/ActorAPI/"+id,
            //datatype: "json",
            //data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.edit = function (id) {
        $http({
            method: "get",
            url: "http://localhost:7130/api/ActorAPI/" + id,
            datatype: "json",
            //data: JSON.stringify(response)
        }).then(function (response) {
            $scope.Id = response.data.Id;
            $scope.Name = response.data.Name;
            $scope.Nationality = response.data.Nationality;
            $scope.DateOfBirth = new Date(response.data.DateOfBirth);
            $scope.Roles = "";
            })

        document.getElementById("btnSave").setAttribute("value", "Edit");
        document.getElementById("btnSave").style.backgroundColor = "green";
        $scope.formTitle = 'Edit Actor';
    }
})  
