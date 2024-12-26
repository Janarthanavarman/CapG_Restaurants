using System.Text.Json.Serialization;
namespace CapG.Models;
public class Dishs{
    public int DishID{get; set;}
    public string DishCode{get; set;}
    public string DishName{get; set;}
    public int DishCategoryID{get; set;}
    public int SpicyLevelID{get; set;}
    public bool IsAvail{get; set;}
    public double Rating{get; set;}
    public double Price{get; set;}
    public virtual DishCategorys DishCategory {get; set;}
    public virtual SpicyLevel SpicyLevel {get; set;}
}