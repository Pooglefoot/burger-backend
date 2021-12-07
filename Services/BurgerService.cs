using BurgerBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBackend.Services;

// Service class to act as a data store for Burgers, to have some data upon building the project.
public static class BurgerService {
    static List<Burger> Burgers {get;}
    static BurgerService() {
        Burgers = new List<Burger> {
            new Burger (
                "Hamburger",
                "Bun, beef, pickles, onions, ketchup and mustard",
                false,
                new Restaurant (
                    "Bob's Burgers",
                    "Bridger Street 32",
                    "15:00 - 22:30"
                )
            ),
            new Burger (
                "Cheeseburger",
                "Bun, beef, cheddar cheese, pickles, onions, ketchup and mustard",
                false,
                new Restaurant (
                    "Generic Gary's",
                    "Stutter Bridge 23",
                    "12:30 - 21:00"
                )
            )
        };
    }

    // Get specific instance of Burger, based on given GUID.
    public static List<Burger> GetAll() {
        return Burgers;
    }

    // Get specific instance of Burger, based on given GUID.
    public static Burger? Get(Guid id) {
        return Burgers.FirstOrDefault(p => p.Id == id);
    }

    // Creates a new instance of Burger and adds it to the List of data (should be sent to database),
    // based on the parameters passed from the controller. Idea is to keep the logic and creation of data
    // strictly in Services, and all the exchanges in the Controller.
    public static Burger Add(string name, string ingredients, bool vegetarian, Restaurant restaurant) {
        Burger burger = new Burger(
            name,
            ingredients,
            vegetarian,
            restaurant
        );

        Burgers.Add(burger);
        return burger;
    }

    // Deletes instance of Restaurant from our data, 
    public static void Delete(Guid id) {
        var burger = Get(id);
        if (burger == null) {
            return;
        }

        Burgers.Remove(burger);
    }

    // Updates an object of type Burger with the given parameters. Requires all parameters to be present in the update.
    // We might consider using Patch instead.
    public static Burger? Update(Burger existingBurger, string name, string ingredients, bool vegetarian) {
        var index = Burgers.FindIndex(p => p.Id == existingBurger.Id);
        if (index == -1) {
            return null;
        }

        existingBurger.Name = name;
        existingBurger.Ingredients = ingredients;
        existingBurger.Vegetarian = vegetarian;

        Burgers[index] = existingBurger;
        return existingBurger;
    }
}