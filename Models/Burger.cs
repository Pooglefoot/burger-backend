namespace BurgerBackend.Models;

public class Burger {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Ingredients { get; set; }

    public bool? Vegetarian { get; set; }

    public Restaurant Restaurant { get; set; }

    public List<Review> Reviews { get; set; }
}