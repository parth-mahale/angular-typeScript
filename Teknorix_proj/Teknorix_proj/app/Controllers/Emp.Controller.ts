module app.emps {
    'use strict';
    interface IEmpScrope {
        Emps: Emp[];
        newEmp: Emp;
        showEmp: Boolean;

        getEmps(): ng.IPromise<Emp[]>;
        addEmp(showEmp: Boolean): ng.IPromise<Emp>;
        showEmpForm(): void;
    }

    class Emp { 
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

    class EmpController implements IEmpScrope {
       
        Emps: Emp[];
        newEmp: Emp;
        showEmp: Boolean;

        $onInit = () => { }; //added

        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) {
            this.getEmps();
            this.showEmp = false;
        }
          
        getEmps(): ng.IPromise<Emp[]> {    
            throw new Error("Method not implemented.");
        }
        addEmp(showEmp: Boolean): ng.IPromise<Emp> {
            throw new Error("Method not implemented.");
        }
        showEmpForm(): void {
            throw new Error("Method not implemented.");
        }
    }   

    angular
        .module('app')
        .controller('app.emps.EmpController', EmpController);
}  