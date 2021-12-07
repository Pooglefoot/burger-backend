using BurgerBackend.Models;

namespace BurgerBackend.Services;

// Service class to act as a data store for Restaurants, to have some data upon building the project.
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

    // GetAll instances of Restaurants, currently just from our mock data.
    public static List<Restaurant> GetAll() {
        return Restaurants;
    }

    // Get specific instance of Restaurant, based on given GUID.
    public static Restaurant? Get(Guid id) {
        return Restaurants.FirstOrDefault(p => p.Id == id);
    }

    // Creates a new instance of Restaurant and adds it to the List of data (should be sent to database),
    // based on the parameters passed from the controller. Idea is to keep the logic and creation of data
    // strictly in Services, and all the exchanges in the Controller.
    public static Restaurant Add(string name, string address, string openingTimes) {
        Restaurant restaurant = new Restaurant (
            name,
            address,
            openingTimes
        );

        Restaurants.Add(restaurant);
        return restaurant;
    }

    // Deletes instance of Restaurant from our data. 
    public static void Delete(Guid id) {
        var restaurant = Get(id);
        if (restaurant == null) {
            return;
        }

        Restaurants.Remove(restaurant);
    }

    // Updates an object of type Restaurant with the given parameters. Requires all parameters to be present in the update.
    // Consider using Patch instead.
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