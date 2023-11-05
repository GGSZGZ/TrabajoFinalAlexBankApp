using Spectre.Console;
using Models;

public class BasicBankOperations
{
    public void DepositMoney(string key)
{
    var ingreso = AnsiConsole.Prompt(
        new TextPrompt<decimal>("¿Cuánto dinero deseas depositar? ")
            .PromptStyle(new Style(foreground: Color.Green))
            .Validate(amount =>
            {
                if (amount <= 0)
                {
                    return ValidationResult.Error("El monto debe ser mayor que cero.");
                }
                return ValidationResult.Success();
            }));

    var note = AnsiConsole.Prompt(new TextPrompt<string>("Motivo: ")
        .PromptStyle(new Style(foreground: Color.Green)))
        .ToString();

    BankDiccionary.dictionaryAccounts[key].MakeDeposit(ingreso, DateTime.Now, note);
}


    public void Withdrawal(string key)
    {
        var retiro = AnsiConsole.Prompt(
            new TextPrompt<decimal>("¿Cuánto dinero deseas retirar? ")
                .ValidationErrorMessage("[red]El monto debe ser mayor que cero.[/]")
                .PromptStyle(Style.Parse("green"))
                .Validate(amount =>
                {
                    if (amount <= 0)
                    {
                        return ValidationResult.Error();
                    }
                    return ValidationResult.Success();
                }));

        var note = AnsiConsole.Prompt(new TextPrompt<string>("Motivo: ").PromptStyle(Style.Parse("green"))).ToString();

        BankDiccionary.dictionaryAccounts[key].MakeWithdrawal(retiro, DateTime.Now, note);
    }

    public void WriteHistory(string key)
    {
        BankDiccionary.dictionaryAccounts[key].writeJsonHistory();
    }

    public void ReadHistory(string key)
    {
        BankDiccionary.dictionaryAccounts[key].readJsonHistory();
    }
}
