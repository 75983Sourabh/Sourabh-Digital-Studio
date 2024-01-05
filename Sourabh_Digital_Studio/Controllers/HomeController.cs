using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sourabh_Digital_Studio.Models;
using DAL;
using BOL;
using BLL;
namespace Sourabh_Digital_Studio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(int Id, string Username, string Emailid, string Phone, string Password)
    {
        User u = new User();
        Console.WriteLine(Id + " " + Username + Emailid + Phone + Password);
        u.Id = Id;
        u.Username = Username;
        u.Emailid = Emailid;
        u.Phone = Phone;
        u.Password = Password;
        DBManager.insertData(u);

        return View();

    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string Username, string Password)
    {
        // System.Console.WriteLine(Username+" "+Password);
        List<User> user = DBManager.GetallUList();
        foreach (User u in user)
        {
            Console.WriteLine(u.Username + u.Password);
            if (u.Username.Equals(Username) && (u.Password.Equals(Password)))
            {
                Console.WriteLine("true");
                Response.Redirect("/Home/Welcome");
            }
            else
            {
                System.Console.WriteLine("Not valid");
            }
        }
        return View();

    }
    public IActionResult Update(string Username, string Password, string Emailid)
    {
        User u = new User();
        u.Username = Username;
        u.Password = Password;
        u.Emailid = Emailid;
        DBManager.UpdateData(u);

        return View();
    }
    public IActionResult Insert(string Username, string Password, string Emailid)
    {
        User u = new User();
        u.Username = Username;
        u.Password = Password;
        u.Emailid = Emailid;
        DBManager.insertData(u);

        return View();
    }
    public IActionResult Delete(string Emailid)
    {
        DBManager.deleteData(Emailid);
        return View();
    }
[HttpGet]
public IActionResult GetById()
    { 
        allUser au = new allUser();
        List<User> user = au.GetallUList();
        ViewData["User"] = user;
        return View();
     
        return View();
    }
[HttpPost]
public IActionResult GetById(int Id)
    {
        
        DBManager.GetById(Id);
        return View();
    }

    public IActionResult Welcome()
    {
        return View();
    }
    public IActionResult List()
    {
        allUser au = new allUser();
        List<User> user = au.GetallUList();
        ViewData["User"] = user;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
