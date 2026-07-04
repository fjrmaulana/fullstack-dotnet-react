namespace BackEnd_App.Models
{
    public class Activity
    {
        public Activity()
        {
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Title { get; set; }
        public System.DateTime Date { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public bool IsCancelled { get; set; }
        public required string City { get; set; }
        public required string Venue { get; set; }
        public double Langitude { get; set; }
        public double Longitude { get; set; }       
    }
}
