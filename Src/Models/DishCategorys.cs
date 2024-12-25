using System.Text.Json.Serialization;
namespace CapG.Models;
public class DishCategorys{
    public int DishCategoryID{get; set;}
    public string DishCategoryName{get; set;}
    [JsonIgnore]
    public virtual ICollection<Dishs> Dishs{get; set;}
}