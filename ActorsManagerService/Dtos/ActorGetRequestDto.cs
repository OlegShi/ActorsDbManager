namespace ActorsManagerService.Dtos
{
    public class ActorGetRequestDto
    {
        const int MaxPageSize = 50;
        public string? ActorName { get; set; }
        public int MinRank { get; set; } = 1;
        public int MaxRank { get; set; } = int.MaxValue;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize { 
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
    }
}
