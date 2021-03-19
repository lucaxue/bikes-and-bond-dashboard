using System.ComponentModel.DataAnnotations;
public class Mission
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int Difficulty { get; set; }
    public string Task { get; set; }
    public string Villain { get; set; } // random names including Bike Authors 
}