using System.ComponentModel.DataAnnotations;

namespace ActorsManagerService.Models
{
    public class Actor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string ?Name { get; set; }

        [Required]
        public string ?Details { get; set; }

        [Required]
        public int Rank { get; set; }
    }
}
