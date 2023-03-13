using Microsoft.AspNetCore.Mvc;
using week_3_basic_Ecommerce.Data;
using week_3_basic_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace week_3_basic_Ecommerce.Controllers {
    public class AddToCartController : Controller {

        private readonly VideoGameContext _context;
        private const string Cart = "ShoppingCart";

        /// <summary>
        /// constructor for AddToCartClass
        /// </summary>
        /// <param name="context"></param>
        public AddToCartController(VideoGameContext context) {
            _context = context;
        }

        public IActionResult AddToCart(int id) {

            Game? gameToAdd = _context.Games.Where(g => g.GameId == id).FirstOrDefault();

            if (gameToAdd == null) {

                //Game with specified id doesn't exist
                TempData["Message"] = "Game does not exist";
                return RedirectToAction("Index", "GamesController1");
            }

            //make CartGameViewModel based on gameInCart to add to cookie
            CartGameViewModel gameInCart = new() {
                GameId = gameToAdd.GameId,
                GameTitle = gameToAdd.Title,
                GamePrice = gameToAdd.Price
            };

            List<CartGameViewModel> cartGames = GetExistingCartData();
            cartGames.Add(gameInCart);

            WriteShoppingCartCookie(cartGames);

            TempData["Message"] = "Game added to cart!";
            return RedirectToAction("Index", "GamesController1");
        }

        private void WriteShoppingCartCookie(List<CartGameViewModel> cartGames) {
            string cookieData = JsonConvert.SerializeObject(cartGames);

            //add gameInCart to shopping cart cookie
            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions() {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Return current list of games in users shoppingCart cookie
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<CartGameViewModel> GetExistingCartData() {
            string? cookie = HttpContext.Request.Cookies[Cart];

            if (string.IsNullOrWhiteSpace(cookie)) {
                return new List<CartGameViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartGameViewModel>>(cookie)!;       
        }

        public IActionResult Summary() {
            //get shopping cart data and convert to list of view model
            List<CartGameViewModel> gamesInCart = GetExistingCartData();
            return View(gamesInCart);
        }

        public IActionResult Remove(int id) {
            List<CartGameViewModel> cartGames = GetExistingCartData();

            CartGameViewModel? targetGame = cartGames.Where(g => g.GameId == id).FirstOrDefault();

            if (targetGame != null) {
                cartGames.Remove(targetGame);
            }

            WriteShoppingCartCookie(cartGames);

            return RedirectToAction(nameof(Summary));
        }
    }
}
