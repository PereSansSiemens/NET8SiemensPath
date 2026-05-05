using Spectre.Console;
using System.Globalization;

AnsiConsole.Write(new FigletText("Unit Conversor").Centered().Color(Color.Green));
AnsiConsole.MarkupLine("[underline green]Welcome to the Unit Conversor App![/]");
AnsiConsole.MarkupLine("[white]Type your option and provide a number below.[/]");
AnsiConsole.MarkupLine("[white](Type exit to finish the program).[/]");

while (true) 
{
    ShowMenu();

    AnsiConsole.MarkupLine("[white]Choose your number option:[/]");
    var input = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));

    if (string.Equals(input.ToLower(), "exit")) { break; }

    else 
    {
        switch (input.Trim())
        {
            case "1":
                AnsiConsole.MarkupLine("[white]OPTION 1 SELECTED[/]");
                AnsiConsole.MarkupLine("[white]Indicate the number to convert below.[/]");

                var num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));

                while (!IsFloatOrInt(num)) 
                {
                    AnsiConsole.MarkupLine("[red]Provide a valid number.[/]");
                    num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));
                }

                var res = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);

                AnsiConsole.Markup("[bold yellow]Conversor:[/]");
                AnsiConsole.MarkupLine($"[white] {num} Kilometers equals {CalcKilometersToMilles(res)} Milles.[/]");

                break;

            case "2":
                AnsiConsole.MarkupLine("[white]OPTION 2 SELECTED[/]");
                AnsiConsole.MarkupLine("[white]Indicate the number to convert below.[/]");

                num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));

                while (!IsFloatOrInt(num))
                {
                    AnsiConsole.MarkupLine("[red]Provide a valid number.[/]");
                    num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));
                }

                res = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);

                AnsiConsole.Markup("[bold yellow]Conversor:[/]");
                AnsiConsole.MarkupLine($"[white] {num} Celsius Degrees equals {CalcCelsiusToFarenheit(res)} Farenheit Degrees.[/]");

                break;

            case "3":
                AnsiConsole.MarkupLine("[white]OPTION 3 SELECTED[/]");
                AnsiConsole.MarkupLine("[white]Indicate the number to convert below.[/]");

                num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));

                while (!IsFloatOrInt(num))
                {
                    AnsiConsole.MarkupLine("[red]Provide a valid number.[/]");
                    num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));
                }

                res = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);

                AnsiConsole.Markup("[bold yellow]Conversor:[/]");
                AnsiConsole.MarkupLine($"[white] {num} Kilograms equals {CalcKilogramsToPounds(res)} Pounds.[/]");

                break;

            case "4":
                AnsiConsole.MarkupLine("[white]OPTION 4 SELECTED[/]");
                AnsiConsole.MarkupLine("[white]Indicate the number to convert below.[/]");

                num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));

                while (!IsFloatOrInt(num))
                {
                    AnsiConsole.MarkupLine("[red]Provide a valid number.[/]");
                    num = AnsiConsole.Prompt(new TextPrompt<string>("[bold yellow]User: [/]"));
                }

                res = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);

                AnsiConsole.Markup("[bold yellow]Conversor:[/]");
                AnsiConsole.MarkupLine($"[white] {num} Liters equals {CalcLitersToGallons(res)} Gallons.[/]");

                break;

            default:
                AnsiConsole.MarkupLine("[red]Not a valid option. Select among the list:[/]");
                break;
        }
    }

}
AnsiConsole.MarkupLine("[white]Bye bye![/]");
void ShowMenu()
{
    AnsiConsole.MarkupLine("1).- Convert Kilometers to milles.");
    AnsiConsole.MarkupLine("2).- Convert Celsius Degrees to Farenheit.");
    AnsiConsole.MarkupLine("3).- Convert Kilograms to pounds.");
    AnsiConsole.MarkupLine("4).- Covert Liters to Gallons.");
    AnsiConsole.MarkupLine("Type exit to end the program.");
}
double CalcKilometersToMilles(double kilometers)
{
    return kilometers * 0.62137119f;
}
double CalcCelsiusToFarenheit(double celsius)
{
    return celsius * 33.8f;
}
double CalcKilogramsToPounds(double kilograms)
{
    return kilograms * 2.20462262f;
}
double CalcLitersToGallons(double liters)
{
    return liters * 0.26417205f;
}

bool IsFloatOrInt(string value)
{
    int intValue;
    float floatValue;
    return Int32.TryParse(value, out intValue) || float.TryParse(value, out floatValue);
}