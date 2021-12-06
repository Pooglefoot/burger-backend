using BurgerBackend.Models;

namespace BurgerBackend.Responses;

class BurgerDetail {
    private string Name { get; set; }
    private string Ingredients { get; set; }
    private bool? Vegetarian { get; set; }
    private RestaurantDetail Restaurant { get; set; }
    private List<ReviewDetail> Reviews { get; set; }

    public BurgerDetail (Burger burger, Restaurant restaurant) {
        this.Name = burger.Name;
        this.Ingredients = burger.Ingredients;
        this.Vegetarian = burger.Vegetarian;
        this.Restaurant = new RestaurantDetail(restaurant);
    }
}