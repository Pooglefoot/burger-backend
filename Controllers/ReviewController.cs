using BurgerBackend.Models;
using BurgerBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class BurgerController : ControllerBase {
    public BurgerController() {}

    // Queries service for all burgers
    [HttpGet]
    public ActionResult<List<Burger>> GetAll() {
        return BurgerService.GetAll();
    }

    // Queries service for specific burger
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id) {
        var burger = BurgerService.Get(id);

        if (burger == null) {
            return NotFound();
        }

        return burger;
    }

    // Adds (creates) a burger object in the data store.
    [HttpPost]
    public IActionResult Create(Burger burger) {
        BurgerService.Add(burger);
        return CreatedAtAction(nameof(Create), new { id = burger.Id }, burger);
    }

    // Updates a Burger in the data store.
    [HttpPut("{id}")]
    public IActionResult Update(int id, Burger burger) {
        if (id != burger.Id) {
            return BadRequest();
        }

        var existingBurger = BurgerService.Get(id);
        if (existingBurger is null) {
            return NotFound();
        }

        BurgerService.Update(burger);

        return NoContent();
    }

    // Deletes a burger from the data store.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var burger = BurgerService.Get(id);

        if (burger is null) {
            return NotFound();
        }

        BurgerService.Delete(id);

        return NoContent();
    }
}