namespace Barcelona.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
