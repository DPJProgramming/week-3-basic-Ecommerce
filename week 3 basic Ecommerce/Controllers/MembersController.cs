using Microsoft.AspNetCore.Mvc;
using week_3_basic_Ecommerce.Data;
using week_3_basic_Ecommerce.Models;

namespace week_3_basic_Ecommerce.Controllers {
    public class MembersController : Controller {

        private readonly VideoGameContext _context;//field for access database

        public MembersController(VideoGameContext context) {//constructor to create object from context class
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel) {

            //add to database
            if (ModelState.IsValid) {
                Member newMember = new() {
                    Email = regModel.Email,
                    Password = regModel.Password,
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                //redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }
    }
}
