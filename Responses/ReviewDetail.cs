using BurgerBackend.Models;

namespace BurgerBackend.Responses;

// Data Transfer Object for displaying Review Model objects
public class ReviewDetail {
    public string Title {get; set;}
    public string? Description {get; set;}
    public int TasteScore {get; set;}
    public int? TextureScore {get; set;}
    public int? VisualScore {get; set;}
    public BurgerDetail Burger {get; set;}

    public ReviewDetail (Review review) {
        this.Title = review.Title;
        this.Description = review.Description;
        this.TasteScore = review.TasteScore;
        this.TextureScore = review.TextureScore;
        this.VisualScore = review.VisualScore;
        this.Burger = new BurgerDetail(review.Burger);
    }
}