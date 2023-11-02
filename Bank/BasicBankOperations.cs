using System;
using Models;


// Clase que contiene los métodos relacionados con la cuenta bancaria
public class BasicBankOperations
{
    public void depositMoney(string key)
    {

        Console.WriteLine("¿Cuanto dinero deseas depositar?");
        decimal ingreso=int.Parse(Console.ReadLine()!);
        Console.WriteLine("Motivo :");
        string note=Console.ReadLine()!;
        BankDiccionary.diccionarioCuentas[key].MakeDeposit(ingreso,DateTime.Now,note);


    }

    public void withDrawal(string key)
    {
         Console.WriteLine("¿Cuanto dinero deseas retirar?");
        decimal retiro=int.Parse(Console.ReadLine()!);
        Console.WriteLine("Motivo :");
        string note=Console.ReadLine()!;
        BankDiccionary.diccionarioCuentas[key].MakeWithdrawal(retiro,DateTime.Now,note);
    }

    

//leer y escribir jsons
    public void writeHistory(string key)
    {
       BankDiccionary.diccionarioCuentas[key].writeJsonHistory();
    }

    public void readHistory(string key)
    {
       BankDiccionary.diccionarioCuentas[key].readJsonHistory();;
    }
}