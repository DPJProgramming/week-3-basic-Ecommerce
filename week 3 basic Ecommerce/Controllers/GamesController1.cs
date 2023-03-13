using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(int? id) {

            const int NumGamesToDisplayPerPage = 3;

            //get total number of games from database math.ceiling rounds up to nearest whole number
            int totalNumberOfProducts = await _context.Games.CountAsync();
            double maxNumPages = Math.Ceiling((double)totalNumberOfProducts/NumGamesToDisplayPerPage);
            int lastPage = Convert.ToInt32(maxNumPages);

            //need page offset to use currentpage and find numgames to skip
            int pageOffset = 1;

            //check if id has a value before setting that value to currentPage
            //                check id       if true  if false
            int currentPage = id.HasValue ? id.Value  : 1;
            //or
            //int currentPage = id ?? 1;

            //Get all games from database
            //method syntax before pagination
            //List<Game> allGames = _context.Games.ToList();

            //query syntax
            List<Game> allGames = await(from game in _context.Games select game)
                                     .Skip(NumGamesToDisplayPerPage * (currentPage - pageOffset))
                                     .Take(NumGamesToDisplayPerPage)
                                     .ToListAsync();

            GameCatalogViewModel catalogModel = new(allGames, lastPage, currentPage);

            //show on website
            return View(catalogModel);
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            Game? gameToEdit = await _context.Games.FindAsync(id); //find game by id

            //if game is not found in database not found exception
            if (gameToEdit == null) {
                return NotFound();
            }

            //send game to view
            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel) {
            //validate info
            if (ModelState.IsValid) {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{gameModel.Title} was updated successfully";
                //redirects to index page
                return RedirectToAction("Index");
            }
            else {

                return View(gameModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if(gameToDelete == null) {
                return NotFound();
            }
            else {
                return View(gameToDelete);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete != null) {
                _context.Games.Remove(gameToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = gameToDelete.Title + " was deleted successfully";
                return RedirectToAction("Index");
            }
            else {
                TempData["Message"] = gameToDelete?.Title + "Was already deleted";
                return RedirectToAction("Index");
            }           
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            Game? gameDetails = await _context.Games.FindAsync(id);

            if (gameDetails == null) {
                return NotFound();
            }
            else {
                return View(gameDetails);
            }
        }
    }
}
