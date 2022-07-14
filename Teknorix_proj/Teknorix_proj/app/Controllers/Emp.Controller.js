var app;
(function (app) {
    var emps;
    (function (emps) {
        'use strict';
        var Emp = /** @class */ (function () {
            function Emp() {
            }
            return Emp;
        }());
        emps.Emp = Emp;
        var Dept = /** @class */ (function () {
            function Dept() {
            }
            return Dept;
        }());
        emps.Dept = Dept;
        var EmpController = /** @class */ (function () {
            function EmpController($http) {
                this.$http = $http;
                this.$onInit = function () { }; //added
                //constructor(private $http: ng.IHttpService, private empService: services.IEmpsService) {
                this.getEmps();
                this.getDepts();
                this.showEmp = false;
            }
            EmpController.prototype.showEmpForms = function (show) {
                this.showEmp = show;
            };
            EmpController.prototype.getEmps = function () {
                var _this = this;
                return this.$http.get('https://localhost:44367/api/Employee/GetAllEmployee')
                    .then(function (response) {
                    _this.emps = response.data;
                });
            };
            EmpController.prototype.getDepts = function () {
                var _this = this;
                return this.$http.get('https://localhost:44367/api/Employee/GetDrpDwnList')
                    .then(function (response) {
                    _this.departmentList = response.data;
                });
            };
            EmpController.prototype.addEmps = function (newemp) {
                var _this = this;
                return this.$http.post('https://localhost:44367/api/Employee/AddEmployees', newemp)
                    .then(function (data) {
                    _this.showEmp = false;
                    _this.newemp = {};
                    _this.emps.push(data);
                    return data;
                });
            };
            EmpController.prototype.removeEmployee = function (id) {
                return this.$http.post('https://localhost:44367/api/Employee/DeleteEmployeeDtls', id)
                    .then(function (data) {
                    //  this.showEmp = false;
                    //   this.newemp = <any>{};
                    //   this.emps.push(<Emp>data);
                    return data;
                });
            };
            //addEmps(emp: Emp): ng.IPromise<Emp> {
            //    return this.$http.post('https://localhost:44367/api/Employee/AddEmployees', emps)
            //        .then((response: ng.IHttpPromiseCallbackArg<Emp>): any => {
            //            return <Emp>response.data;
            //        });
            //}
            EmpController.prototype.showEmpForm = function () {
                throw new Error("Method not implemented.");
            };
            // static $inject = ['$http', 'app.services.EmpService'];
            EmpController.$inject = ['$http'];
            return EmpController;
        }());
        angular
            .module('app')
            .controller('app.emps.EmpController', EmpController);
    })(emps = app.emps || (app.emps = {}));
})(app || (app = {}));
//# sourceMappingURL=Emp.Controller.js.map