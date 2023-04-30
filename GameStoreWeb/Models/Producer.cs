using GameStoreWeb.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace GameStoreWeb.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage ="The profile picture is required")]

        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 words")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage ="Biography is required")]
        
        public string Bio { get; set; }

        public List<Game> Games { get; set; }
    }
}
