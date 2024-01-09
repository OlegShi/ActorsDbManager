namespace ActorsManagerService.Dtos
{
    public class ActorUpdateRequestDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Details { get; set; }

        public int Rank { get; set; }
    }
}
