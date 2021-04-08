using System.ComponentModel.DataAnnotations;
public class Bike
{
  public long? Id { get; set; }
  [Required]
  public string Genre { get; set; }
  [Required]
  public string Author { get; set; }
  [Required]
  public string Color { get; set; }
  [Required]
  public string Title { get; set; }
}