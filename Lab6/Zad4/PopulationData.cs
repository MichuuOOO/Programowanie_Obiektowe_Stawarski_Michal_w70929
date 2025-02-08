using System.Text.Json;
using System.Text.Json.Serialization;

public class PopulationData
{
    [JsonPropertyName("country")]
    public CountryInfo Country { get; set; }

    [JsonPropertyName("date")]
    public string YearString { get; set; }

    [JsonPropertyName("value")]
    public JsonElement PopulationElement { get; set; }

    public int Year
    {
        get
        {
            if (int.TryParse(YearString, out int result))
                return result;
            else
                return 0;
        }
    }

    public long? Population
    {
        get
        {
            if (PopulationElement.ValueKind == JsonValueKind.Number)
                return PopulationElement.GetInt64();
            if (PopulationElement.ValueKind == JsonValueKind.String && long.TryParse(PopulationElement.GetString(), out long result))
                return result;
            if (PopulationElement.ValueKind == JsonValueKind.Null)
                return null;
            return null;
        }
    }
}

public class CountryInfo
{
    [JsonPropertyName("id")]
    public string Code { get; set; }

    [JsonPropertyName("value")]
    public required string Name { get; set; }
}
