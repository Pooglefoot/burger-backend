using BurgerBackend.Models;

namespace BurgerBackend.Services;

// Service class to act as a data store for burgers, to have some data upon building the project.
public static class RestaurantService {
    static List<Restaurant> Restaurants { get; }
    static int nextId = 3;
    static RestaurantService() {
        Restaurants = new List<Restaurant> {
            new Restaurant { Id = 1, Name = "Hamburger", Ingredients = "Bun, beef, pickles, onions, ketchup and mustard", Vegetarian = false, Restaurant = "Generic Gary's"},
            new Restaurant { Id = 2, Name = "Cheeseburger", Ingredients = "Bun, beef, cheddar cheese, pickles, onions, ketchup and mustard", Vegetarian = false, Restaurant = "Generic Gary's"}
        };
    }

    public static List<Restaurant> GetAll() {
        return Restaurants;
    }

    public static Restaurant? Get(int id) {
        return Restaurants.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Restaurant restaurant) {
        restaurant.Id = nextId++;
        Restaurant.Add(restaurant);
    }

    public static void Delete(int id) {
        var restaurant = Get(id);
        if (restaurant is null) {
            return;
        }

        Restaurant.Remove(restaurant);
    }

    public static void Update(Restaurant restaurant) {
        var index = Restaurant.FindIndex(p => p.Id == restaurant.Id);
        if (index == -1) {
            return;
        }

        Burgers[index] = restaurant;
    }
}