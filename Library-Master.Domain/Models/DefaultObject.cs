using System.Text.Json.Serialization;

namespace Library_Master.Core.Models
{
    public class DefaultObject
    {
        [JsonIgnore] public int Id { get; set; }
    }
}