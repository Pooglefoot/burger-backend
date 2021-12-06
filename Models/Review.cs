namespace BurgerBackend.Models;

public class Review {
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public int TasteScore { get; set; }

    public int? TextureScore { get; set; }

    public int? VisualScore { get; set; }

    public Burger Burger { get; set; }
}