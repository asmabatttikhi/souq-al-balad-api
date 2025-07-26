namespace AdsApiSQLite.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public double Price { get; set; }
        public string Images { get; set; } = ""; // JSON string
        public string Phone { get; set; } = "";
        public string Category { get; set; } = "";
    }
}