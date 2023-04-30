using GameStoreWeb.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreWeb.Data.ViewComponents
{
    public class ShoppingCartsSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartsSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
