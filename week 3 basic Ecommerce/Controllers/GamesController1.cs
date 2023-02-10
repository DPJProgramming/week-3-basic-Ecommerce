using Microsoft.AspNetCore.Mvc;
using week_3_basic_Ecommerce.Data;
using week_3_basic_Ecommerce.Models;

namespace week_3_basic_Ecommerce.Controllers {
    public class GamesController1 : Controller {

        //field for controller class to work with database
        private readonly VideoGameContext _context;

        //constructor
        public GamesController1(VideoGameContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game) {
            if (ModelState.IsValid) {

                //add to database
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                //show success message
                ViewData["Message"] = $"{game.Title} was added succesfully";

                return View();
            }

            return View(game);
        }
    }
}
