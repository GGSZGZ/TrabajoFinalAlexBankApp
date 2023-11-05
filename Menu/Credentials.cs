using Spectre.Console;
using Models;

public class Credentials
{
    public void CreateAccount()
    {
        BankAccount accountNew;
        string accountHolder;
        int initialBalance;
        string key;

        do
        {
            accountHolder = AnsiConsole.Prompt(
                new TextPrompt<string>("Nombre del titular : ").Validate(name =>
                {
                    if (int.TryParse(name, out _))
                    {
                        return ValidationResult.Error("Debes introducir un titular válido");
                    }
                    return ValidationResult.Success();
                })).ToUpper();
        } while (int.TryParse(accountHolder, out _));

        do
        {
            initialBalance = AnsiConsole.Prompt(
                new TextPrompt<int>("Balance inicial : ").PromptStyle("green").Validate(balance =>
                {
                    if (balance <= 0)
                    {
                        return ValidationResult.Error("Debes introducir un balance inicial válido");
                    }
                    return ValidationResult.Success();
                }));
            try
            {
                accountNew = new BankAccount(accountHolder, initialBalance);
            }
            catch (FormatException)
            {
                AnsiConsole.MarkupLine("[red]Debes introducir valores válidos[/]");
                continue;
            }
            break;
        } while (true);

        do
        {
            key = AnsiConsole.Prompt(new TextPrompt<string>("Introduce una clave para esta cuenta: ").PromptStyle("blue")).ToString();

            if (BankDiccionary.dictionaryAccounts.ContainsKey(key))
            {
                AnsiConsole.MarkupLine("[red]La clave ya está en uso. Por favor, utiliza una clave diferente.[/]");
            }
            else
            {
                BankDiccionary.dictionaryAccounts.Add(key, accountNew);
                AnsiConsole.MarkupLine("[green]Cuenta creada exitosamente.[/]");
                break;
            }
        } while (true);
    }

    public string Login()
    {
        string holder = AnsiConsole.Prompt(new TextPrompt<string>("Dime el nombre del titular : ").PromptStyle("green")).ToString().ToUpper();
        string key = AnsiConsole.Prompt(new TextPrompt<string>("Clave de la cuenta : ").PromptStyle("green")).ToString();

        if (BankDiccionary.dictionaryAccounts.ContainsKey(key) && BankDiccionary.dictionaryAccounts[key].Owner == holder)
        {
            AnsiConsole.MarkupLine("[green]El nombre del titular coincide con la cuenta.[/]");
            return key;
        }
        else
        {
            AnsiConsole.MarkupLine("[red]ERROR[/]");
            return null!;
        }
    }
}
