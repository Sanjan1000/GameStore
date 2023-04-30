using GameStoreWeb.Data.Base;
using GameStoreWeb.Models;

namespace GameStoreWeb.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context): base(context)
        {
            
        }
    }
}
