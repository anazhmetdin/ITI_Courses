using Departments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Departments.Controllers
{
    public class DepartmentsController : Controller
    {
        private HttpClient _httpClient = new ();
        // GET: DepartmentsController
        public ActionResult Index()
        {
            var responce = _httpClient.GetAsync("https://localhost:7173/api/Departments").Result;
            string x = responce.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<List<Department>>(x);
            return View(content);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            var responce = _httpClient.GetAsync($"https://localhost:7173/api/Departments/{id}").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string x = responce.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(x);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                var responce = _httpClient.PostAsync($"https://localhost:7173/api/Departments", new StringContent(JsonSerializer.Serialize(department), Encoding.UTF8, "application/json")).Result;
                if (responce.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var responce = _httpClient.GetAsync($"https://localhost:7173/api/Departments/{id}").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string x = responce.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(x);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                var responce = _httpClient.PutAsync($"https://localhost:7173/api/Departments/{id}", new StringContent(JsonSerializer.Serialize(department), Encoding.UTF8, "application/json")).Result;
                if (responce.StatusCode == HttpStatusCode.NoContent)
                    return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var responce = _httpClient.GetAsync($"https://localhost:7173/api/Departments/{id}").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string x = responce.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(x);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department department)
        {
            try
            {
                var responce = _httpClient.DeleteAsync($"https://localhost:7173/api/Departments/{id}").Result;
                if (responce.StatusCode == HttpStatusCode.NoContent && id == department.Id)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View(department);
            }
        }
    }
}
