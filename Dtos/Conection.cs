using Newtonsoft.Json;

namespace ConectionStrings.Dtos;

public class Connection
{
    [JsonProperty("dataSource")]
    public string DataSource { get; set; }

    [JsonProperty("initialCatalog")]
    public string InitialCatalog { get; set; }

    [JsonProperty("UserId")]
    public string UserId { get; set; }

    [JsonProperty("Password")]
    public string Password { get; set; }

    public override string ToString()
    {
        return $"data source={DataSource};initial catalog={InitialCatalog};User Id={UserId};Password={Password};Persist Security Info=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True";
    }

    public string ToJson()
    {
        return $"[dataSource={DataSource} initialCatalog={InitialCatalog} UserId={(string.IsNullOrEmpty(UserId) ? "USERID" : UserId)} Password={(string.IsNullOrEmpty(Password) ? "PASSWORD" : Password)}]";
    }
}
