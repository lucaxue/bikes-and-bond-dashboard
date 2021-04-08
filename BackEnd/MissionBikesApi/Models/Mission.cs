using System.ComponentModel.DataAnnotations;
public class Mission
{
  public long? Id { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Location { get; set; }
  [Required]
  public int Difficulty { get; set; }
  [Required]
  public string Task { get; set; }
  [Required]
  public string Villain { get; set; }
}