using GameStoreWeb.Data.Cart;
using GameStoreWeb.Data.Services;
using GameStoreWeb.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GameStoreWeb.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IGamesService gamesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _gamesService = gamesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {


            return View();
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}

        //public async Task<IActionResult> AddItemToShoppingCart(int id)
        //{
        //    //var item = await _gamesService.GetMovieByIdAsync(id);

        //    if (item != null)
        //    {
        //        _shoppingCart.AddItemToCart(item);
        //    }
        //    return RedirectToAction(nameof(ShoppingCart));
        //}

        //public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        //{
        //    //var item = await _gamesService.GetMovieByIdAsync(id);

            //if (item != null)
            //{
            //    _shoppingCart.RemoveItemFromCart(item);
            //}
            //return RedirectToAction(nameof(ShoppingCart));
        //}

        //public async Task<IActionResult> CompleteOrder()
        //{
        //    var items = _shoppingCart.GetShoppingCartItems();
            

            //await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            //await _shoppingCart.ClearShoppingCartAsync();

            //return View("OrderCompleted");
//        }
//    }
//}
