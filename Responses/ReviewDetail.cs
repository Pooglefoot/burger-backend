using BurgerBackend.Models;

namespace BurgerBackend.Responses;

public class ReviewDetail {
    private string Title { get; set; }
    private string? Description { get; set; }
    private int TasteScore { get; set; }
    private int? TextureScore { get; set; }
    private int? VisualScore { get; set; }
    private BurgerDetail Burger { get; set; }

    public ReviewDetail (Review review) {
        this.Title = review.Title;
        this.Description = review.Description;
        this.TasteScore = review.TasteScore;
        this.TextureScore = review.TextureScore;
        this.VisualScore = review.VisualScore;
    }
}