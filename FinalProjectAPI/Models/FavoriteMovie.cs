namespace FinalProjectAPI.Models

{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
