//let myApp = angular.module('imdb', []);

//let actorCtrl = function () {
//    this.unTexto = "Hello world from angular!";
//}
//myApp.controller('actorCtrl', actorCtrl);

//console.log("a ver cual es la joda catrejijeptas");

var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {    

    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.Emp_Name = $scope.EmpName;
            $scope.Employe.Emp_City = $scope.EmpCity;
            $scope.Employe.Emp_Age = $scope.EmpAge;
            $http({
                method: "post",
                url: "http://localhost:39209/Employee/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "";
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
    $scope.edit = function (actor) {
        document.getElementById("EmpID_").value = Emp.Emp_Id;
        $scope.EmpName = Emp.Emp_Name;
        $scope.EmpCity = Emp.Emp_City;
        $scope.EmpAge = Emp.Emp_Age;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "green";
        document.getElementById("spn").innerHTML = "Edit actor";
    }
})  
