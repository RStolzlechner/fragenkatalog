using System.Text.Json.Serialization;

namespace fragenkatalog;

public class QandA
{
    public int Id { get; set; }
    public string Course { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public int Points { get; set; }

    [JsonIgnore]
    public int Order { get; set; }
}