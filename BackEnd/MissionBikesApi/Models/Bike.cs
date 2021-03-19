using System.ComponentModel.DataAnnotations;
public class Bike
{
    public long? Id { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public string Color { get; set; }
    public string Title { get; set; } //name of bike eg, Red Roller 
}