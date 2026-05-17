using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // SIMPLE LOGIN (FOR SCHOOL PROJECT)
        if (username == "admin" && password == "1234")
        {
            HttpContext.Session.SetString("Admin", "true");
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid login";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}