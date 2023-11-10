using ConectionStrings.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConectionStrings.Controllers;

public class ConnectionStringModifier
{
    public void ModifyConnectionString(string path, Connection newConnection)
    {
        if(newConnection.Password is null || newConnection.UserId is null)
        {
            newConnection.UserId = "USER";
            newConnection.Password = "PASSWORD";
        }

        var config = JObject.Parse(File.ReadAllText(path));

        foreach (var setting in config["ConnectionStrings"].Children<JProperty>())
        {
            setting.Value = newConnection.ToString();
        }

        File.WriteAllText(path, config.ToString());
    }


    public T ReadSettings<T>(string caminhoDoArquivo)
    {
        using (StreamReader file = File.OpenText(caminhoDoArquivo))
        {
            JsonSerializer serializer = new JsonSerializer();
            T configuracoes = (T)serializer.Deserialize(file, typeof(T));
            return configuracoes;
        }
    }
}
