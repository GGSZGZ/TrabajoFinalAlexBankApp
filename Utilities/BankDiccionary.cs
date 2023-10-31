using Models;

public static class BankDiccionary
{
    public static Dictionary<string, BankAccount> Cuentas { get; } = new Dictionary<string, BankAccount>();
}