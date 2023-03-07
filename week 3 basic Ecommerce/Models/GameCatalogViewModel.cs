namespace week_3_basic_Ecommerce.Models {
    public class GameCatalogViewModel {

        public GameCatalogViewModel(List<Game> games, int lastPage, int currentPage) { 
            Games= games;
            LastPage= lastPage;
            CurrentPage= currentPage;
        }

        public List<Game> Games { get; set; }

        /// <summary>
        /// last page of game catalog calculated by # of games / games displayed per page
        /// </summary>
        public int LastPage {get; set; }

        /// <summary>
        /// current page user is viewing
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
