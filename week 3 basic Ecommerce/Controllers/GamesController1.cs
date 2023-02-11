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

        public async  Task<IActionResult> Index() {

            //Get all games from database
            List<Game> allGames = _context.Games.ToList();

            //show on website
            return View(allGames);
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

        //pass id which was clicked from view asp-route-id
        public async Task<IActionResult> Edit(int id) {
            Game gameToEdit = await _context.Games.FindAsync(id); //find game by id

            //if game is not found in database not foound exception
            if(gameToEdit == null) {
                return NotFound();
            }

            //send game to view
            return View(gameToEdit);
        }
    }
}
