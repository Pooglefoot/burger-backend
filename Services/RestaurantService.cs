using BurgerBackend.Models;

namespace BurgerBackend.Services;

// Service class to act as a data store for burgers, to have some data upon building the project.
public static class RestaurantService {
    static List<Restaurant> Restaurants {get;}
    static RestaurantService() {
        Restaurants = new List<Restaurant> {
            new Restaurant (
                "Bob's Burgers",
                "Bridger Street 32",
                "15:00 - 22:30"
            ),
            new Restaurant (
                "Generic Gary's",
                "Stutter Bridge 23",
                "12:30 - 21:00"
            )
        };
    }

    public static List<Restaurant> GetAll() {
        return Restaurants;
    }

    public static Restaurant? Get(Guid id) {
        return Restaurants.FirstOrDefault(p => p.Id == id);
    }

    public static Restaurant Add(string name, string address, string openingTimes) {
        Restaurant restaurant = new Restaurant (
            name,
            address,
            openingTimes
        );

        Restaurants.Add(restaurant);
        return restaurant;
    }

    public static void Delete(Guid id) {
        var restaurant = Get(id);
        if (restaurant == null) {
            return;
        }

        Restaurants.Remove(restaurant);
    }

    public static Restaurant? Update(Restaurant existingRestaurant, string name, string address, string openingTimes) {
        var index = Restaurants.FindIndex(p => p.Id == existingRestaurant.Id);
        if (index == -1) {
            return null;
        }

        existingRestaurant.Name = name;
        existingRestaurant.Address = address;
        existingRestaurant.OpeningTimes = openingTimes;

        Restaurants[index] = existingRestaurant;
        return existingRestaurant;
    }
}