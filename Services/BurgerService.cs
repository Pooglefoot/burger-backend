using BurgerBackend.Models;

namespace BurgerBackend.Services;

// Service class to act as a data store for burgers, to have some data upon building the project.
public static class BurgerService {
    static List<Burger> Burgers { get; }
    static int nextId = 3;
    static BurgerService() {
        Burgers = new List<Burger> {
            new Burger { Id = 1, Name = "Hamburger", Ingredients = "Bun, beef, pickles, onions, ketchup and mustard", Vegetarian = false, Restaurant = "Generic Gary's"},
            new Burger { Id = 2, Name = "Cheeseburger", Ingredients = "Bun, beef, cheddar cheese, pickles, onions, ketchup and mustard", Vegetarian = false, Restaurant = "Generic Gary's"}
        };
    }

    public static List<Burger> GetAll() {
        return Burgers;
    }

    public static Burger? Get(int id) {
        return Burgers.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Burger burger) {
        burger.Id = nextId++;
        Burgers.Add(burger);
    }

    public static void Delete(int id) {
        var burger = Get(id);
        if (burger is null) {
            return;
        }

        Burgers.Remove(burger);
    }

    public static void Update(Burger burger) {
        var index = Burgers.FindIndex(p => p.Id == burger.Id);
        if (index == -1) {
            return;
        }

        Burgers[index] = burger;
    }
}