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
     public IActionResult Register(){
        return View();
    }
    [HttpPost]
     public IActionResult Register(int Id,string Username,string Emailid,string Phone,string Password)
    { 
         User u=new User();
        Console.WriteLine(Id+" "+Username+Emailid+Phone+Password);
        u.Id=Id;
        u.Username=Username;
        u.Emailid=Emailid;
        u.Phone=Phone;
        u.Password=Password;
        DBManager.RegisterData(u);
        
        return View();

    }
    [HttpGet]
      public IActionResult Login(){
        return View();
    }
    [HttpPost]
     public IActionResult Login(string Username,string Password)
    { 
              System.Console.WriteLine(Username+" "+Password);
        List<User>user=DBManager.GetallUList();
        foreach(User u in user){
            Console.WriteLine(u.Username+u.Password);
            if(u.Username.Equals(Username)&&u.Password.Equals(Password)){
                Console.WriteLine("Valid User");
                Response.Redirect("/Home/Welcome");
            }
        }return View();

    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
