using ConectionStrings.Dtos;

namespace ConectionStrings.Controllers;

public class ConsoleDataPresenter
{
    public static void ShowDataConsole(IList<Connection> value)
    {
        Console.WriteLine("{0,-5} | {1,-30} | {2,-30} | {3,-10} | {4,-10}", "ID", "Data Source", "Initial Catalog", "User ID", "Password");
        Console.WriteLine(new string('-', 100));

        for (int i = 0; i < value.Count; i++)
        {
            var connection = value[i];
            Console.WriteLine("{0,-5} | {1,-30} | {2,-30} | {3,-10} | {4,-10}",
                i + 1,
                connection.DataSource,
                connection.InitialCatalog,
                (string.IsNullOrEmpty(connection.UserId) ? "USER" : connection.UserId),
                (string.IsNullOrEmpty(connection.Password) ? "PASSWORD" : connection.Password));
        }
    }
}
