using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class MvcController : Controller
    {
        // GET: Mvc

        HttpClient client = new HttpClient();  
        public ActionResult Index()
        {
            List<Employee> emplist = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.GetAsync("EmpApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emplist = display.Result;
            }
            return View(emplist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.PostAsJsonAsync<Employee>("EmpApi",emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
             return View("Create");
        }

        public ActionResult Details(int id) 
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.GetAsync("EmpApi?id="+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.GetAsync("EmpApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.PutAsJsonAsync<Employee>("EmpApi", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.GetAsync("EmpApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [System.Web.Mvc.HttpPost,System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44342/api/EmpApi");
            var response = client.DeleteAsync("EmpApi/"+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}