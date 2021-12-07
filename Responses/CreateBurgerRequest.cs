using BurgerBackend.Models;

namespace BurgerBackend.Responses;

public class CreateBurgerRequest {
        public string Name {get; set;} = string.Empty;
        public string Ingredients {get; set;} = string.Empty;
        public bool Vegetarian {get; set;}
        public Guid RestaurantId {get; set;}
}