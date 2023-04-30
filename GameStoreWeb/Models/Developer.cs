using GameStoreWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace GameStoreWeb.Models
{
    public class Developer :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Names")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name must be between 3 to 50 letters")]
        public string FullName { get; set;}


        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography  is required")]
        public string Bio { get; set; }
        public List<Developer_Games> Developer_Games { get; set; }
    }
}
