using BurgerBackend.Models;

namespace BurgerBackend.Responses;

public class CreateRestaurantRequest {
        public string Name {get; set;} = string.Empty;
        public string Address {get; set;} = string.Empty;
        public string OpeningTimes {get; set;} = string.Empty;
}