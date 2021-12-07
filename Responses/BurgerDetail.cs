using BurgerBackend.Models;

namespace BurgerBackend.Responses;

// Data Transfer Object for displaying Burger Model Objects
public class BurgerDetail {
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Ingredients {get; set;}
    public bool Vegetarian {get; set;}
    public RestaurantSummary Restaurant {get; set;}

    public BurgerDetail (Burger burger) {
        this.Id = burger.Id;
        this.Name = burger.Name;
        this.Ingredients = burger.Ingredients;
        this.Vegetarian = burger.Vegetarian;
        this.Restaurant = new RestaurantSummary(burger.Restaurant);
    }
}