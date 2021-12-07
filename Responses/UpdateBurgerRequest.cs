namespace BurgerBackend.Responses;

// Data Transfer Object for updating Burger Model objects
public class UpdateBurgerRequest {
        public string Name {get; set;} = string.Empty;
        public string Ingredients {get; set;} = string.Empty;
        public bool Vegetarian {get; set;}
    }