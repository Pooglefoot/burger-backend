using BurgerBackend.Models;

namespace BurgerBackend.Responses;

public class RestaurantDetail {
    private string url { get; set; }
    private string Name { get; set; }
    private string Address { get; set; }
    private string OpeningTimes { get; set; }
    public List<Burger> Burgers  { get; set; }

    public RestaurantDetail (Restaurant restaurant) {
        this.url = $"/restaurants/{restaurant.Id}";
        this.Name = restaurant.Name;
        this.Address = restaurant.Address;
        this.OpeningTimes = restaurant.OpeningTimes;
    }
}