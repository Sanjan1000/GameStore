using GameStoreWeb.Data.Base;
using GameStoreWeb.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreWeb.Models
{
    public class NewGameVM
    {
        public int Id { get; set; }
        public string? Logo { get; set; }
        [Display(Name = "Game Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Display(Name = "Game Description ")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Display(Name = "Game Price ")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Display(Name = "Game ImageURL ")]
        [Required(ErrorMessage = "ImageURL is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Game ReleaseDate ")]
        [Required(ErrorMessage = "ReleaseDate is Required")]

        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Game GameCategory ")]
        [Required(ErrorMessage = "GameCategory is Required")]

        public GameCategory GameCategory { get; set; }
        [Display(Name = "Game Developer Id ")]
        [Required(ErrorMessage = "DeveloperIds is Required")]
        public List<int> DeveloperIds { get; set; }
        public int ProducerId { get; set;}

      
    }
}
