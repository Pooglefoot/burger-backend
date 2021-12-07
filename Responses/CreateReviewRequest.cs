using BurgerBackend.Models;

namespace BurgerBackend.Responses;

public class CreateReviewRequest {
        public string Title {get; set;} = string.Empty;
        public string? Description {get; set;}
        public int TasteScore {get; set; }
        public int? TextureScore {get; set;}
        public int? VisualScore {get; set;}
        public Guid BurgerId {get; set;}
}