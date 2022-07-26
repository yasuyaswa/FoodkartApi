using FoodkartApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodkartMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly FoodAppContext _foodAppContext;
        public LoginController(FoodAppContext foodAppContext)
        {
            _foodAppContext = foodAppContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection collection)
        {
            string msg = "";

            Admin a = new Admin();
            a.UserId = collection["UserId"];
            a.AdminPass = collection["AdminPass"];
            using (var client = new HttpClient())
            {
                var query = from d in _foodAppContext.Admins
                            where d.UserId == a.UserId && d.AdminPass == a.AdminPass
                            select new Admin()
                            {
                                UserId = d.UserId,
                                AdminPass = d.AdminPass
                            };
                List<Admin> k = query.ToList();

                foreach (var admin in k)
                {

                    if (a.UserId == admin.UserId && a.AdminPass == admin.AdminPass)
                    {
                        return RedirectToAction("Index", "Menus");
                    }



                }

                return View();

            }

        }
    }
}
