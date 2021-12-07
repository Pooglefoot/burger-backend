using BurgerBackend.Responses;

namespace BurgerBackend.Models;

public class Burger {
    public Guid Id {get; set;} = Guid.NewGuid();

    public string Name {get; set;}

    public string Ingredients {get; set;}

    public bool Vegetarian {get; set;}

    public Restaurant Restaurant {get; set;}

    public List<Review> Reviews {get; set;} = new List<Review>();

    // Constructor for Burger object
    public Burger (string name, string ingredients, bool vegetarian, Restaurant restaurant) {
        this.Name = name;
        this.Ingredients = ingredients;
        this.Vegetarian = vegetarian;
        this.Restaurant = restaurant;
    }
}