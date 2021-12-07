using BurgerBackend.Models;
using BurgerBackend.Services;
using BurgerBackend.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class BurgerController : ControllerBase {
    public BurgerController() {}

    // Queries service for all burgers
    [HttpGet]
    public ActionResult<List<BurgerDetail>> getAllBurgers() {
        var enumBurgers = BurgerService.GetAll().Select(b => new BurgerDetail(b));
        
        if (enumBurgers == null) {
            return NotFound();
        }

        List<BurgerDetail> burgers = enumBurgers.ToList();

        return burgers;
    }

    // Queries service for specific burger
    [HttpGet("{id}")]
    public ActionResult<BurgerDetail> getBurger(Guid id) {
        var burger = BurgerService.Get(id);

        // If burger not found, return error 404.
        if (burger == null) {
            return NotFound();
        }

        return new BurgerDetail(burger);
    }

    // Adds (creates) a burger object in the data store.
    [HttpPost]
    public IActionResult createBurger(CreateBurgerRequest form) {
        var restaurant = RestaurantService.Get(form.RestaurantId);

        if (restaurant == null) {
            return NotFound();
        }

        // Sends Data to service which creates and returns a new Burger Model Object, and tells us what id it has.
        Burger newBurger = BurgerService.Add(form.Name, form.Ingredients, form.Vegetarian, restaurant);
        return CreatedAtAction(nameof(createBurger), new {id = newBurger.Id}, newBurger);
    }

    // Updates a Burger in the data store.
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateBurgerRequest form) {
        var burger = BurgerService.Get(id);

        // If burger not found, return error 404.
        if (burger == null) {
            return NotFound();
        }

        // Sends Burger object and DTO Data to the Service in order to update Burger object.
        burger = BurgerService.Update(burger, form.Name, form.Ingredients, form.Vegetarian);

        // If, after attempting to update, there is no burger object, return error 404.
        // Means that the burger was not found in the data. Should not happen.
        if (burger == null) {
            return NotFound();
        }

        // If everything has been successfully processed, return 204.
        return NoContent();
    }

    // Deletes a burger from the data store.
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        var burger = BurgerService.Get(id);

        if (burger == null) {
            return NotFound();
        }

        BurgerService.Delete(id);

        return NoContent();
    }
}