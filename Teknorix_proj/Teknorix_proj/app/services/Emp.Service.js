var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var Emp = /** @class */ (function () {
            function Emp() {
            }
            return Emp;
        }());
        services.Emp = Emp;
        var EmpService = /** @class */ (function () {
            function EmpService($http) {
                this.$http = $http;
            }
            EmpService.prototype.getEmps = function () {
                return this.$http.get('/Employees/IndexVM')
                    .then(function (response) {
                    return response.data;
                });
            };
            EmpService.$inject = ['$http'];
            return EmpService;
        }());
        factory.$inject = ['$http'];
        function factory($http) {
            return new EmpService($http);
        }
        angular
            .module('app')
            .factory('app.services.EmpService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=Emp.Service.js.map