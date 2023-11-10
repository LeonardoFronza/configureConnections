using ConectionStrings.Controllers;
using ConectionStrings.Dtos;
using Newtonsoft.Json;

ConnectionStringModifier modifier = new ConnectionStringModifier();

string path, jsonFilePath = "";
path = "yours-directory-here";

var directories = new PathNavigator();

#if DEBUG
jsonFilePath = $"C:\\{path}\\ConectionStrings\\Jsons\\data.json";
directories = modifier.ReadSettings<PathNavigator>($"D:\\{path}\\ConectionStrings\\Jsons\\directories.json");
#else
path = AppDomain.CurrentDomain.BaseDirectory.ToString();
jsonFilePath = $"{path}/Connections.json";
directories = modifier.ReadSettings<PathNavigator>($"{path}/ConectionStrings/Jsons/directories.json");
#endif

string json = File.ReadAllText(jsonFilePath);
List<Connection> value = JsonConvert.DeserializeObject<List<Connection>>(json);
ConsoleDataPresenter.ShowDataConsole(value);

Console.WriteLine(" ");
Console.Write("Enter the ID of the connection you want to use: ");
int id = Convert.ToInt32(Console.ReadLine());

if (id > 0 && id <= value.Count)
{
    var connection = value[id - 1];

    foreach (var item in directories.Path)
    {
#if DEBUG
        modifier.ModifyConnectionString($"D:\\{path}\\{item}", connection);
#else
        modifier.ModifyConnectionString($"{item}", connection);
#endif
    }
    Console.Write($"You selected the connection with ID: {connection.InitialCatalog}");
}
else
{
    Console.WriteLine("Invalid ID. Please try again.");
}