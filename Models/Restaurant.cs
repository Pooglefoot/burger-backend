namespace BurgerBackend.Models;

public class Restaurant {
    public Guid Id {get; set;} = Guid.NewGuid();

    public string Name {get; set;}

    public string Address {get; set;}

    // Should probably be DateTime, is String for now.
    public string OpeningTimes {get; set;}

    public List<Burger> Burgers {get; set;} = new List<Burger>();

    public Restaurant (string name, string address, string openingTimes) {
        this.Name = name;
        this.Address = address;
        this.OpeningTimes = openingTimes;
    }
}