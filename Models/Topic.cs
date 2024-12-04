public class Topic
{
  public Guid Id {get; set;}
  public required string Title {get; set;}
  public required string Content {get; set;}
  public required string ImageUrl {get; set;}
  public required DateTime CreatedAt {get; set;}
  public required User CreatedBy {get; set;}
}
