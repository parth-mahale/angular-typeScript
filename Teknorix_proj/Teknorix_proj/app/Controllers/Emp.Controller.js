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
        var EmpController = /** @class */ (function () {
            function EmpController($http) {
                this.$http = $http;
                this.$onInit = function () { }; //added
                this.getEmps();
                this.showEmp = false;
            }
            EmpController.prototype.getEmps = function () {
                throw new Error("Method not implemented.");
            };
            EmpController.prototype.addEmp = function (showEmp) {
                throw new Error("Method not implemented.");
            };
            EmpController.prototype.showEmpForm = function () {
                throw new Error("Method not implemented.");
            };
            EmpController.$inject = ['$http'];
            return EmpController;
        }());
        angular
            .module('app')
            .controller('app.emps.EmpController', EmpController);
    })(emps = app.emps || (app.emps = {}));
})(app || (app = {}));
//# sourceMappingURL=Emp.Controller.js.map