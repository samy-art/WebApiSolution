using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmpApiController : ApiController
    {
        MVCWebDBEntities1 ent = new MVCWebDBEntities1();

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = ent.Employees.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeesById(int id)
        {
            var emp = ent.Employees.Where(m=>m.Eid == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPost]
        public IHttpActionResult EmplInsert(Employee emp)
        {
            ent.Employees.Add(emp);
            ent.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            ent.Entry(e).State = System.Data.Entity.EntityState.Modified;
            ent.SaveChanges();


            //var emp = ent.Employees.Where(m=>m.Eid==e.Eid).FirstOrDefault();
            //if (emp != null) 
            //{
            //    emp.Eid = e.Eid;
            //    emp.EmpName = e.EmpName;
            //    emp.DeptID = e.DeptID;
            //    ent.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = ent.Employees.Where(m => m.Eid == id).FirstOrDefault();
            ent.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            ent.SaveChanges();
            return Ok();
        }

    }
}
