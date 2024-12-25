using System.Text.Json.Serialization;
namespace CapG.Models;
public class SpicyLevel{
    public int SpicyLevelID{get; set;}
    public string SpicyLevelName{get; set;}

    [JsonIgnore]
    public virtual ICollection<Dishs> Dishs{get; set;}
}