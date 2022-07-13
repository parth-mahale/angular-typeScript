using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teknorix_proj.Models;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teknorix_proj.Controllers
{
    public class EmployeesController : Controller
    {
        private Tenorix_DBContext db = new Tenorix_DBContext();

        // GET: Employees
       // [HttpPost]
        public ActionResult Index(string searchBy, string search)
        {
            return View();
            //if (searchBy == "Firstname")
            //{
            //    return View(db.Employees.Where(x => x.emp_fname.StartsWith(search) || search == null).ToList());
            //}
            //else
            //{
            //    return View(db.Employees.Where(x => x.emp_lname.StartsWith(search) || search == null).ToList());
            //}  
        }  
        public ActionResult IndexVM(string searchBy, string search)
        {
            if (searchBy == "Firstname")
            {
                db.Configuration.ProxyCreationEnabled = false;
                return Json(db.Employees.Where(x => x.emp_fname.StartsWith(search) || search == null).ToList(),JsonRequestBehavior.AllowGet);
            }
            else 
            {
                db.Configuration.ProxyCreationEnabled = false;
                return Json(db.Employees.Where(x => x.emp_lname.StartsWith(search) || search == null).ToList(),JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult searchDtls(Employee employee)
        {
            if (employee.searchBy == "Firstname")
            {
                var temp = db.Employees.Where(x => x.emp_fname.StartsWith(employee.search) || employee.search == null).ToList();
              //  string JsonTexts = JsonConvert.SerializeObject(temp);
                //JsonConvert.SerializeObject(temp, new JsonSerializerSettings()
                //{
                //    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //    Formatting = Formatting.Indented
                //});
                return  Json(JsonConvert.SerializeObject(temp, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                }));
            }
            else
            {
                return Json(db.Employees.Where(x => x.emp_lname.StartsWith(employee.search) || employee.search == null).ToList());
            }
        }
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        var EmployeeList = (db.Employees.Join(db.Departments, x => x.dept_id, y => y.dept_id,
        //        (x, y) => new Employee
        //        {
        //            emp_id = x.emp_id,
        //            emp_fname = x.emp_fname,
        //            emp_lname = x.emp_lname,
        //            emp_gender = x.emp_gender,
        //            emp_address = x.emp_address,
        //            emp_phone_no = x.emp_phone_no,
        //            emp_mobile_no = x.emp_mobile_no,
        //            emp_desgn_id = x.emp_desgn_id,
        //            dept_id = y.dept_name
        //        }
        //        )).ToList();
        //        return View(EmployeeList);
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
        // GET: Employees/Details/5 
        public ActionResult Details(int? id)   
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            LoadDsgnDrpDwnList();
            LoadDeptDrpDwnList();     
            // ModelState.Clear();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "emp_id,emp_fname,emp_lname,emp_gender,emp_address,emp_phone_no,emp_mobile_no,emp_desgn_id,dept_id")] Employee employee)
        [HttpPost]
        public ActionResult Create([Bind(Include = "emp_id,emp_fname,emp_lname,emp_gender,emp_address,emp_phone_no,emp_mobile_no,emp_desgn_id,dept_id")] Employee employee)

        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Json(employee, JsonRequestBehavior.AllowGet);
               //return RedirectToAction("Index");
            }
            return Json(employee,JsonRequestBehavior.AllowGet);
            //return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            LoadDsgnDrpDwnList();
            LoadDeptDrpDwnList();
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_fname,emp_lname,emp_gender,emp_address,emp_phone_no,emp_mobile_no,emp_desgn_id,dept_id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            LoadDsgnDrpDwnList();
            LoadDeptDrpDwnList();    
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
            
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoadDsgnDrpDwnList();
            LoadDeptDrpDwnList();
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void LoadDsgnDrpDwnList()
        {
            try
            {
                List<Designation> desgnList = new List<Designation>();
                desgnList = db.Designations.ToList();
                desgnList.Insert(0, new Designation { Desgn_id = 0, Desgn_name = "Please Select Designation" });
                ViewBag.DesgnList = desgnList;

            }
            catch
            {

            }
        }
        public void LoadDeptDrpDwnList()
        {
            try
            {
                List<Department> deptList = new List<Department>();
                deptList = db.Departments.ToList();
                deptList.Insert(0, new Department { dept_id = 0.ToString(), dept_name = "Please Select Department" });
                ViewBag.DeptList = deptList;
            }
            catch
            {

            }
        }
    }
}
