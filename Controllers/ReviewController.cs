using BurgerBackend.Models;
using BurgerBackend.Services;
using BurgerBackend.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase {
    public ReviewController() {}

    // Queries service for all reviews
    [HttpGet]
    public ActionResult<List<ReviewDetail>> getAllReviews() {
        var enumReviews = ReviewService.GetAll().Select(r => new ReviewDetail(r));

        if (enumReviews == null) {
            return NotFound();
        }

        List<ReviewDetail> reviews = enumReviews.ToList();

        return reviews;
    }

    // Queries service for specific review
    [HttpGet("{id}")]
    public ActionResult<ReviewDetail> Get(Guid id) {
        var review = ReviewService.Get(id);

        // If review isn't found, return error 404.
        if (review == null) {
            return NotFound();
        }

        return new ReviewDetail(review);
    }

    // Adds (creates) a review object in the data store.
    [HttpPost]
    public IActionResult createReview(CreateReviewRequest form) {
        var burger = BurgerService.Get(form.BurgerId);

        if (burger == null) {
            return NotFound();
        }

        Review newReview = ReviewService.Add(form.Title, form.Description, form.TasteScore, form.TextureScore, form.VisualScore, burger);

        // Sends Data to service which creates and returns a new Review Model Object, and tells us what id it has.
        return CreatedAtAction(nameof(createReview), new { id = newReview.Id }, newReview);
    }

    // Updates a review in the data store.
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateReviewRequest form) {
        var review = ReviewService.Get(id);

        if (review == null) {
            return NotFound();
        }

        // Sends Review object and DTO Data to the Service in order to update Review object.
        review = ReviewService.Update(review, form.Title, form.Description, form.TasteScore, form.TextureScore, form.VisualScore);

        // If, after attempting to update, there is no review object, return error 404.
        // Means that the review was not found in the data. Should not happen.
        if (review == null) {
            return NotFound();
        }

        return NoContent();
    }

    // Deletes a review from the data store.
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        var review = ReviewService.Get(id);

        if (review is null) {
            return NotFound();
        }

        ReviewService.Delete(id);

        return NoContent();
    }
}