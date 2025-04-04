using System.Reflection;
using Spectre.Console;

namespace ExcelReader.Util;

public static class TableVisualisation
{
    public static void ShowData<T>(List<T> data) where T : class
    {
        var table = new Table();
        if (!data.Any())
        {
            AnsiConsole.MarkupLine("[red]No data found.[/]");
            return;
        }
        
        AnsiConsole.MarkupLine("[bold cyan]Data found. Printing Data:[/]");
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        
        foreach (var property in properties)
        {
            table.AddColumn(property.Name);
        }

        foreach (var item in data)
        {
            var rowData = properties.Select(property => property.GetValue(item, null).ToString()).ToArray();
            table.AddRow(rowData);
        }
        AnsiConsole.Write(table);
        Console.ReadKey();
    }
}