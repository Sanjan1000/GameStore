using System.ComponentModel.DataAnnotations;

namespace GameStoreWeb.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set;}
        public string Bio { get; set; }
        public List<Developer_Games> Developer_Games { get; set; }
    }
}
