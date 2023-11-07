using Spectre.Console;
using System;

public class MainMenu
{
    private static BasicBankOperations account = new BasicBankOperations();
    private static Credentials credentials = new Credentials();
    private static string key = "";

    public static void BeginMenu()
    {
        var option = 0;
        var secondOption = 0;

        do
        {
            ShowMenu();
            option = ReadOption();

            switch (option)
            {
                case 1:
                    credentials.CreateAccount();
                    break;
                case 2:
                    key = credentials.Login();

                    if (key == null)
                    {
                        break;
                    }
                    account.WriteHistory(key);
                    do
                    {
                        ShowSecondMenu();
                        secondOption = ReadSecondOption();
                        BankMenu(secondOption, key);
                    } while (secondOption != 4);
                    break;
            }
        } while (option != 3);
    }

    private static void ShowMenu()
{
    AnsiConsole.MarkupLine(@"[yellow]1:[/] [bold]Crear cuenta[/]");
    AnsiConsole.MarkupLine(@"[yellow]2:[/] [bold]Iniciar sesión[/]");
    AnsiConsole.MarkupLine(@"[yellow]3:[/] [bold]Salir[/]");
    Console.Write("Elige una opción: ");
}

private static void ShowSecondMenu()
{
    
        AnsiConsole.MarkupLine("[yellow]1:[/] [bold]Depositar dinero[/]");
        AnsiConsole.MarkupLine("[yellow]2:[/] [bold]Retirar dinero[/]");
        AnsiConsole.MarkupLine("[yellow]3:[/] [bold]Listado de operaciones[/]");
        AnsiConsole.MarkupLine("[yellow]4:[/] [bold]Salir[/]");
        Console.Write("Elige una opción: ");
}


    

    private static int ReadOption()
{
    int option;
    do
    {
        try
        {
            option = int.Parse(Console.ReadLine()!);
            if (option <= 0 || option > 3)
            {
                AnsiConsole.MarkupLine("[red]Debes introducir un valor entre 1 y 3[/]");
            }
            else
            {
                break;
            }
        }
        catch (FormatException)
        {
            AnsiConsole.MarkupLine("[red]Debes introducir un valor numérico[/]");
        }
    } while (true);

    return option;
}


    private static int ReadSecondOption()
    {
        int option;

        do
        {
            try
            {
                option = int.Parse(Console.ReadLine()!);

                if (option < 1 || option > 4)
                {
                    
                    AnsiConsole.MarkupLine("[red]Debes introducir valores comprendidos entre 1 y 4[/]");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                AnsiConsole.MarkupLine("[red]Debes introducir valores numéricos[/]");
            }
        } while (true);

        return option;
    }

    private static void BankMenu(int secondOption, string key)
    {
        BasicBankOperations operatingAccount = new BasicBankOperations();
        switch (secondOption)
        {
            case 1:
                operatingAccount.DepositMoney(key);
                operatingAccount.WriteHistory(key);
                break;
            case 2:
                operatingAccount.Withdrawal(key);
                operatingAccount.WriteHistory(key);
                break;
            case 3:
                operatingAccount.ReadHistory(key);
                break;
        }
    }
}
