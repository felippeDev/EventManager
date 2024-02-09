namespace EventManager.API.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ImageURL { get; set; }
        public string? Location { get; set; }
        public required string Date { get; set; }
        public int Allotment { get; set; }
        public int Slots { get; set; }
    }
}