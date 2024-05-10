using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

public class EmployeeTestController : Controller
{
    [HttpGet, Route("/test")]
    public async Task<IActionResult> Index()
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.GetAsync("https://localhost:7051/api/Default/GetAll");
        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);

        return View(values);
    }

    [HttpGet, Route("/test/add/{id?}")]
    public async Task<IActionResult> add(int? id)
    {
        if (id != null && id != 0)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7051/api/Default/GetEmployeeById/{id}");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Class1>(jsonString);
            return View(value);
        }
        return View();
    }

    [HttpPost, Route("/test/add")]
    public async Task<IActionResult> add(Class1 person)
    {
        var httpClient = new HttpClient();
        var stringa = JsonConvert.SerializeObject(person);
        var jsonEmployee = new StringContent(stringa, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync($"https://localhost:7051/api/Default/Add", jsonEmployee);
        if (response.IsSuccessStatusCode)
        {
            RedirectToAction("Index");
        }
        return View();
    }

    [Route("/test/delete/{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.DeleteAsync($"https://localhost:7051/api/Default/delete/" + id);
        if (response.IsSuccessStatusCode)
        {
            RedirectToAction("Index");
        }
        return Ok();
    }

    [HttpPost]
    [Route("/editProfile")]
    public async Task<IActionResult> editEmployee(Class1 person)
    {
        var httpClient = new HttpClient();
        var stringa = JsonConvert.SerializeObject(person);
        var jsonEmployee = new StringContent(stringa, Encoding.UTF8, "application/json");
        await httpClient.PutAsync($"https://localhost:7051/api/Default/EmployeeUpdate", jsonEmployee);

        return View();
    }
}

public class Class1
{
    public int Id { get; set; }
    public string Name { get; set; }
}

