//let myApp = angular.module('imdb', []);

//let actorCtrl = function () {
//    this.unTexto = "Hello world from angular!";
//}
//myApp.controller('actorCtrl', actorCtrl);

//console.log("a ver cual es la joda catrejijeptas");

var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {    
    $scope.getMovDone = false;
    $scope.isVisible = false;
    $scope.formTitle = 'Add new Actor';
    $scope.movieIdSelected = null; 

    //postActor
    $scope.PostActor = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            let Actor = {};
            Actor.Name = $scope.Name;
            Actor.Nationality = $scope.Nationality;
            Actor.DateOfBirth = $scope.DateOfBirth;
            Actor.Roles = null;
            if ($scope.getMovDone != false) {
                Actor.Roles = [{ nameDto: $scope.nameDto, MovieId: $scope.movieIdSelected }];
            }
                        
            $http({
                method: "post",
                url: "http://localhost:7130/api/ActorAPI/",
                datatype: "json",
                data: JSON.stringify(Actor)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Name = "";
                $scope.Nationality = "";
                $scope.DateOfBirth = "";
            })
        } else {
            let Actor = {};
            Actor.Id = $scope.Id;
            Actor.Name = $scope.Name;
            Actor.Nationality = $scope.Nationality;
            Actor.DateOfBirth = $scope.DateOfBirth;
            Actor.Roles = null;
            $http({
                method: "put",
                url: "http://localhost:7130/api/ActorAPI/" + Actor.Id,
                datatype: "json",
                data: JSON.stringify(Actor)
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

    //get all-----------------
    $scope.GetAllData = function () {
        $scope.getMovDone = false;
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
            
            })

        document.getElementById("btnSave").setAttribute("value", "Edit");
        document.getElementById("btnSave").style.backgroundColor = "green";
        $scope.formTitle = 'Edit Actor';
    }
    $scope.popRoles = function () {
        if ($scope.isVisible != true ) {
            $scope.isVisible = $scope.isVisible = true; 
            
            return;
        }
        $scope.isVisible = $scope.isVisible = false;        
    };
})  
