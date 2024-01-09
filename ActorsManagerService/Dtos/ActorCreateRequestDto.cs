using System.ComponentModel.DataAnnotations;

namespace ActorsManagerService.Dtos
{
    public class ActorCreateRequestDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Details { get; set; }

        [Required]
        public int Rank { get; set; }
    }
}
