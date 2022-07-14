module app.emps {
    'use strict';

    // import Emp = app.services.Emp;


    interface IEmpScope {

        emps: Emp[];
        getDepts(): ng.IPromise<Dept[]>;
        departmentList: Dept[];

        newemp: Emp;
        showEmp: Boolean;

        getEmps(): ng.IPromise<Emp[]>;
        addEmps(newemp: Emp): ng.IPromise<Emp>;

        //removeEmployee(id: Emp): ng.IPromise<Emp>;

        showEmpForms(show: Boolean): void;
        showEmpForm(): void;
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
    export class Dept {
        deptid: string;
        deptName: string;
    }
    class EmpController implements IEmpScope {

        emps: Emp[];
        departmentList: Dept[];
        newemp: Emp;
        showEmp: Boolean;

        $onInit = () => { }; //added

        // static $inject = ['$http', 'app.services.EmpService'];

        static $inject = ['$http'];
       

        constructor(private $http: ng.IHttpService) {
            //constructor(private $http: ng.IHttpService, private empService: services.IEmpsService) {
            this.getEmps();
            this.getDepts();
            this.showEmp = false;
        }
       
        showEmpForms(show: Boolean): void {
            this.showEmp = show;
        }

        getEmps(): ng.IPromise<Emp[]> {
            return this.$http.get('https://localhost:44367/api/Employee/GetAllEmployee')
                .then((response: ng.IHttpPromiseCallbackArg<Emp[]>): any => {
                    this.emps = <Emp[]>response.data;
                });
        }
        getDepts(): ng.IPromise<Dept[]> {
            return this.$http.get('https://localhost:44367/api/Employee/GetDrpDwnList')
                .then((response: ng.IHttpPromiseCallbackArg<Dept[]>): any => {
                    this.departmentList = <Dept[]>response.data;
                });
        }
        addEmps(newemp: Emp): ng.IPromise<Emp> {
            return this.$http.post('https://localhost:44367/api/Employee/AddEmployees', newemp)
                .then((data: ng.IHttpPromiseCallbackArg<Emp>): any => {
                    this.showEmp = false;
                    this.newemp = <any>{};
                    this.emps.push(<Emp>data);
                    return <Emp>data;
                });
        }
        removeEmployee(id)  {
            return this.$http.post('https://localhost:44367/api/Employee/DeleteEmployeeDtls', id)
                .then((data: ng.IHttpPromiseCallbackArg<Emp>): any => {
                    //  this.showEmp = false;
                    //   this.newemp = <any>{};
                    //   this.emps.push(<Emp>data);
                    return <Emp>data;
                });
        }
        //addEmps(emp: Emp): ng.IPromise<Emp> {
        //    return this.$http.post('https://localhost:44367/api/Employee/AddEmployees', emps)
        //        .then((response: ng.IHttpPromiseCallbackArg<Emp>): any => {
        //            return <Emp>response.data;
        //        });
        //}
        showEmpForm(): void {
            throw new Error("Method not implemented.");
        }
    }

    angular
        .module('app')
        .controller('app.emps.EmpController', EmpController);
}  