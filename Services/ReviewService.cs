using BurgerBackend.Models;

namespace BurgerBackend.Services;

// Service class to act as a data store for Reviews, to have some data upon building the project.
public static class ReviewService {
    static List<Review> Reviews {get;}
    static ReviewService() {
        Reviews = new List<Review> {
            new Review (
                "Great Burger",
                "Fantastic, but ugly burger!",
                10,
                9,
                2,
                new Burger (
                    "Hamburger",
                    "Bun, beef, pickles, onions, ketchup and mustard",
                    false,
                    new Restaurant (
                        "Bob's Burgers",
                        "Bridger Street 32",
                        "15:00 - 22:30"
                    )
                )
            ),
            new Review (
                "Terrible Burger",
                "Terrible but beautiful-looking burger!",
                5,
                3,
                9,
                new Burger (
                    "Cheeseburger",
                    "Bun, beef, cheddar cheese, pickles, onions, ketchup and mustard",
                    false,
                    new Restaurant(
                        "Generic Gary's",
                        "Stutter Bridge 23",
                        "12:30 - 21:00"
                    )
                )
            )
        };
    }

    public static List<Review> GetAll() {
        return Reviews;
    }

    public static Review? Get(Guid id) {
        return Reviews.FirstOrDefault(p => p.Id == id);
    }

    public static Review Add(string title, string? description, int tasteScore, int? textureScore, int? visualScore, Burger burger) {
        Review review = new Review (
            title,
            description,
            tasteScore,
            textureScore,
            visualScore,
            burger
        );

        Reviews.Add(review);
        return review;
    }

    public static void Delete(Guid id) {
        var review = Get(id);
        if (review is null) {
            return;
        }

        Reviews.Remove(review);
    }

    public static Review? Update(Review existingReview, string title, string? description, int tasteScore, int? textureScore, int? visualScore) {
        var index = Reviews.FindIndex(p => p.Id == existingReview.Id);
        if (index == -1) {
            return null;
        }

        existingReview.Title = title;
        existingReview.Description = description;
        existingReview.TasteScore = tasteScore;
        existingReview.TextureScore = textureScore;
        existingReview.VisualScore = visualScore;

        Reviews[index] = existingReview;
        return existingReview;
    }
}