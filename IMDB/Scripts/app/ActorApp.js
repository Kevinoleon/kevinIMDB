//let myApp = angular.module('imdb', []);

//let actorCtrl = function () {
//    this.unTexto = "Hello world from angular!";
//}
//myApp.controller('actorCtrl', actorCtrl);

//console.log("a ver cual es la joda catrejijeptas");

var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {    

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
            $scope.Employe = {};
            $scope.Employe.Emp_Name = $scope.EmpName;
            $scope.Employe.Emp_City = $scope.EmpCity;
            $scope.Employe.Emp_Age = $scope.EmpAge;
            $scope.Employe.Emp_Id = document.getElementById("EmpID_").value;
            $http({
                method: "post",
                url: "http://localhost:39209/Employee/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
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
    //$scope.edit = function (id) {
    //    document.getElementById("EmpID_").value = Emp.Emp_Id;
    //    $scope.EmpName = Emp.Emp_Name;
    //    $scope.EmpCity = Emp.Emp_City;
    //    $scope.EmpAge = Emp.Emp_Age;
    //    document.getElementById("btnSave").setAttribute("value", "Update");
    //    document.getElementById("btnSave").style.backgroundColor = "green";
    //    document.getElementById("spn").innerHTML = "Edit actor";
    //}
})  
