using BurgerBackend.Models;

namespace BurgerBackend.Responses;

// Data Transfer Object for displaying Restaurant Model objects
public class RestaurantSummary {
    public Guid Id {get; set;}
    public string name {get; set;}
    public string address {get; set;}
    public string openingTimes {get; set;}
    public List<Burger> burgers  {get; set;}

    public RestaurantSummary (Restaurant restaurant) {
        this.Id = restaurant.Id;
        this.name = restaurant.Name;
        this.address = restaurant.Address;
        this.openingTimes = restaurant.OpeningTimes;
        this.burgers = restaurant.Burgers;
    }
}