using System.Text.Json.Serialization;

namespace CapG.Models.Dto;
public class DishDto
{
    [JsonPropertyName("dish_code")]
    public string DishCode{get; set;}
    [JsonPropertyName("name")]
    public string DishName{get; set;}
    [JsonPropertyName("category")]
    public string DishCategoryName{get; set;}
    [JsonPropertyName("spicy_level")]
    public string SpicyLevelName{get; set;}
    [JsonPropertyName("available")]
    public bool IsAvail{get; set;}
    public double Rating{get; set;}
    public double Price{get; set;}
}


