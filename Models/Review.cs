namespace BurgerBackend.Models;

public class Review {
    public Guid Id {get; set;} = Guid.NewGuid();

    public string Title {get; set;}

    public string? Description {get; set;}

    public int TasteScore {get; set;}

    public int? TextureScore {get; set;}

    public int? VisualScore {get; set;}

    public Burger Burger {get; set;}

    public Review (string title, string? description, int tasteScore, int? textureScore, int? visualScore, Burger burger) {
        this.Title = title;
        this.Description = description;
        this.TasteScore = tasteScore;
        this.TextureScore = textureScore;
        this.VisualScore = visualScore;
        this.Burger = burger;
    }
}