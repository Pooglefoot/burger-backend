namespace BurgerBackend.Models;

public class Restaurant {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string OpeningTimes { get; set; }

    public List<Burger> Burgers  { get; set; }
}