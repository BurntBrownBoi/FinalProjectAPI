namespace FinalProjectAPI.Models

{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string Cuisine { get; set; }
        public string Ingredients { get; set; }
        public bool IsVegetarian { get; set; }
    }
}
