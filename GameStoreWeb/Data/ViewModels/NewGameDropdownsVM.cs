using GameStoreWeb.Models;

namespace GameStoreWeb.Data.ViewModels
{
    public class NewGameDropdownsVM
    {
        public NewGameDropdownsVM()
        {
            Producers = new List<Producer>();
           
            Developers = new List<Developer>();
        }

        public List<Producer> Producers { get; set; }
        public List<Developer> Developers { get; set; }
        
    }
}

