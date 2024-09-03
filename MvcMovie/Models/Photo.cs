namespace MvcMovie.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? MovieId { get; set; }
    }
}
