using System;
using Models;


// Clase que contiene los métodos relacionados con la cuenta bancaria
public class GenericCode
{
    
    public void createAccount()
    {
        bool credentials=false;
        bool keyComplete=false;
        BankAccount accountNew=new BankAccount();
        bool titularNumerico=false;
        int intValue;
        string titular;
        //parametros de usuario
        do{
        Console.WriteLine("Nombre del titular : ");
        titular=Console.ReadLine()!.ToUpper();
    //si lo consigue transformar a numero pedimos que repita
        if (int.TryParse(titular,out intValue))
    {
        Console.WriteLine("Debes introducir un titular válido");
        titularNumerico=true;
    }else{
        titularNumerico=false;
    }
        }while(titularNumerico==true);
        do{
        Console.WriteLine("Balance inicial : ");
        try{
        int initialBalance=int.Parse(Console.ReadLine()!);
        credentials=true;
        //objeto banco
        accountNew=new BankAccount(titular,initialBalance);
        }catch(FormatException){
            Console.WriteLine("Debes introducir valores válidos");
        }
        }while(credentials==false);
        do{
        //clave diccionario
        string clave="";
        bool keyValid=false;
    do{
        try{
        Console.WriteLine("Introduce una clave para esta cuenta: ");
        clave = Console.ReadLine()!;
        keyValid=false;
        }catch(FormatException){
            keyValid=true;
            Console.WriteLine("La sintaxis es incorrecta");
        }
    }while(keyValid==true);
        //si la clave ya existe exigimos una nueva
          if (BankDiccionary.Cuentas.ContainsKey(clave))
        {
            Console.WriteLine("La clave ya está en uso. Por favor, utiliza una clave diferente.");
        }
        else
        {
            BankDiccionary.Cuentas.Add(clave, accountNew);
            Console.WriteLine("Cuenta creada exitosamente.");
            keyComplete=true;
        }
        }while(keyComplete==false);

    }

    public void depositMoney(string key)
    {

        Console.WriteLine("¿Cuanto dinero deseas depositar?");
        decimal ingreso=int.Parse(Console.ReadLine()!);
        Console.WriteLine("Motivo :");
        string note=Console.ReadLine()!;
        BankDiccionary.Cuentas[key].MakeDeposit(ingreso,DateTime.Now,note);


    }

    public void withDrawal(string key)
    {
         Console.WriteLine("¿Cuanto dinero deseas retirar?");
        decimal retiro=int.Parse(Console.ReadLine()!);
        Console.WriteLine("Motivo :");
        string note=Console.ReadLine()!;
        BankDiccionary.Cuentas[key].MakeWithdrawal(retiro,DateTime.Now,note);
    }

    // public void operationHistory(string key)
    // {
    //    Console.WriteLine(BankDiccionary.Cuentas[key].GetAccountHistory());
    // }


//leer y escribir jsons
    public void writeHistory(string key)
    {
       BankDiccionary.Cuentas[key].writeJsonHistory();
    }

    public void readHistory(string key)
    {
       BankDiccionary.Cuentas[key].readJsonHistory();;
    }



    public string login(){
         Console.WriteLine("Dime el nombre del titular");
        string titular=Console.ReadLine()!.ToUpper();
        Console.WriteLine("Clave de la cuenta");
        string key=Console.ReadLine()!;

        if (BankDiccionary.Cuentas.ContainsKey(key)){
    // Verificar si el nombre del titular coincide
    if (BankDiccionary.Cuentas[key].Owner == titular){
        Console.WriteLine("El nombre del titular coincide con la cuenta.");
        return key;
        
    }
    else
    {
        Console.WriteLine("ERROR");
       
    }
}else{
    Console.WriteLine("La clave no corresponde a ninguna cuenta.");
    
    }
    return null!;
    }
}