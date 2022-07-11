angular.module('EmployeeDetails.EmployeesController', [])
    .controller('EmployeeDtsController', ['$scope', '$http', function ($scope, $http) {
        $scope.model = {};
        $scope.states = { 
            showEmpForm: false
        };

        $scope.new = {
            emp: {}
        };


        $http({
            method: 'GET',
            url: '/Employees/IndexVM'
        }).then(function (data) {
            $scope.model = data;
        });

           
        $scope.showEmpForms = function (show) {
            $scope.states.showEmpForm = show;
        };

        $scope.addEmps = function () {
            $http({
                method: 'POST',
                url: '/Employees/Create',     
                data: $scope.new.emp   
            }).then(function (data) {
                $scope.model.emp.push(data);

                //.post('Employees/Create', $scope.new.emp).success(function (data) {
                //$scope.model.emp.push(data);
            });
        }


    }
    ]);