using FoodkartApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodkartMVC.Controllers
{
    public class CLoginController : Controller
    {
        private readonly FoodAppContext _foodAppContext;
        public CLoginController(FoodAppContext foodAppContext)
        {
            _foodAppContext = foodAppContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CLogin(IFormCollection collection)
        {
            string msg = "";

            Customer a = new Customer();
            a.CustomerMobile = Convert.ToInt64(collection["CustomerMobile"]);
            a.CustomerPass= collection["CustomerPass"];
            using (var client = new HttpClient())
            {
                var query = from d in _foodAppContext.Customers
                            where d.CustomerMobile== a.CustomerMobile && d.CustomerPass == a.CustomerPass
                            select new Customer()
                            {
                                CustomerMobile = d.CustomerMobile,
                                CustomerPass = d.CustomerPass
                            };
                List<Customer> k = query.ToList();

                foreach (var customer in k)
                {

                    if (a.CustomerMobile == customer.CustomerMobile && a.CustomerPass == customer.CustomerPass)
                    {
                        return RedirectToAction("Index", "Menus");
                    }



                }

                return View();

            }

        }
    }
}
