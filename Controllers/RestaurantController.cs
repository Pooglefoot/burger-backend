using BurgerBackend.Models;
using BurgerBackend.Services;
using BurgerBackend.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase {
    public RestaurantController() {}

    // Queries service for all restaurants
    [HttpGet]
    public ActionResult<List<RestaurantSummary>> getAllRestaurants() {
        // Select returns the more generic type IEnumerable.
        var enumRestaurants = RestaurantService.GetAll().Select(r => new RestaurantSummary(r));
        
        if (enumRestaurants == null) {
            return NotFound();
        }

        // As the rest of the system is working with lists, we must convert IEnumerable variable to List.
        List<RestaurantSummary> restaurants = enumRestaurants.ToList();

        return restaurants;
    }

    // Queries service for specific restaurant
    [HttpGet("{id}")]
    public ActionResult<RestaurantSummary> getRestaurant(Guid id) {
        var restaurant = RestaurantService.Get(id);

        // If restaurant not found, return error 404.
        if (restaurant == null) {
            return NotFound();
        }

        return new RestaurantSummary(restaurant);
    }

    // Adds (creates) a restaurant object in the data store.
    [HttpPost]
    public IActionResult createRestaurant(CreateRestaurantRequest form) {

        // Sends Data to service which creates and returns a new Restaurant Model Object, and tells us what id it has.
        Restaurant newRestaurant = RestaurantService.Add(form.Name, form.Address, form.OpeningTimes);
        return CreatedAtAction(nameof(createRestaurant), new { id = newRestaurant.Id }, newRestaurant);
    }

    // Updates a restaurant in the data store.
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateRestaurantRequest form) {
        var restaurant = RestaurantService.Get(id);

        if (restaurant == null) {
            return NotFound();
        }

        restaurant = RestaurantService.Update(restaurant, form.Name, form.Address, form.OpeningTimes);

        // If, after attempting to update, there is no restaurant object, return error 404.
        // Means that the restaurant was not found in the data. Should not happen.
        if (restaurant == null) {
            return NotFound();
        }

        // If everything has been successfully processed, return 204.
        return NoContent();
    }

    // Deletes a restaurant from the data store.
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        var restaurant = RestaurantService.Get(id);

        if (restaurant == null) {
            return NotFound();
        }

        RestaurantService.Delete(id);

        // If item has been successfully deleted, return 204.
        return NoContent();
    }
}