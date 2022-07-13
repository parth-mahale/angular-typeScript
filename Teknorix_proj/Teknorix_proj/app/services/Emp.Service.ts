module app.services {
    'use strict'
   export interface IEmpsService {
        getEmps(): ng.IPromise<Emp[]>
    }

    export class Emp {
        emp_id: string;
        emp_fname: string;
        emp_lname: string;
        emp_gender: string;
        emp_address: string;
        emp_phone_no: string;
        emp_mobile_no: string;
        emp_desgn_id: string;
        dept_id: string;
    }
    class EmpService implements IEmpsService {
        static $inject = ['$http'];

        constructor(private $http: ng.IHttpService) {

        }
        getEmps(): ng.IPromise<Emp[]> {
            return this.$http.get('/Employees/IndexVM')
                .then((response: ng.IHttpPromiseCallbackArg<Emp[]>): any => {
                    return <Emp[]>response.data;
                });
        }    
    }

    factory.$inject = ['$http']
    function factory($http: ng.IHttpService) {
        return new EmpService($http);
    }

    angular
        .module('app')
        .factory('app.services.EmpService', factory);
}