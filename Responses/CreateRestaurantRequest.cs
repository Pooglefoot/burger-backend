using BurgerBackend.Models;

namespace BurgerBackend.Responses;

// Data Transfer Object for creating Restaurant Model objects
public class CreateRestaurantRequest {
        public string Name {get; set;} = string.Empty;
        public string Address {get; set;} = string.Empty;
        public string OpeningTimes {get; set;} = string.Empty;
}