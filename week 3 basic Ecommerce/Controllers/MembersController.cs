using Microsoft.AspNetCore.Mvc;

namespace week_3_basic_Ecommerce.Controllers {
    public class MembersController : Controller {

        public IActionResult Register() {
            return View();
        }
    }
}
