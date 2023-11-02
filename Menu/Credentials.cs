using System;
using Models;

public class Credentials{
    public void createAccount()
    {
        bool credentials=false;
        bool keyComplete=false;
        BankAccount accountNew=new BankAccount();
        bool numericHolder=false;
        int intValue;
        string accountHolder;
        //parametros de usuario
        do{
        Console.WriteLine("Nombre del titular : ");
        accountHolder=Console.ReadLine()!.ToUpper();
    //si lo consigue transformar a numero pedimos que repita
        if (int.TryParse(accountHolder,out intValue))
    {
        Console.WriteLine("Debes introducir un titular válido");
        numericHolder=true;
    }else{
        numericHolder=false;
    }
        }while(numericHolder==true);
        do{
        Console.WriteLine("Balance inicial : ");
        try{
        int initialBalance=int.Parse(Console.ReadLine()!);
        credentials=true;
        //objeto banco
        accountNew=new BankAccount(accountHolder,initialBalance);
        }catch(FormatException){
            Console.WriteLine("Debes introducir valores válidos");
        }
        }while(credentials==false);
        do{
        //clave diccionario
        string key="";
        bool keyValid=false;
    do{
        try{
        Console.WriteLine("Introduce una clave para esta cuenta: ");
        key = Console.ReadLine()!;
        keyValid=false;
        }catch(FormatException){
            keyValid=true;
            Console.WriteLine("La sintaxis es incorrecta");
        }
    }while(keyValid==true);
        //si la clave ya existe exigimos una nueva
          if (BankDiccionary.dictionaryAccounts.ContainsKey(key))
        {
            Console.WriteLine("La clave ya está en uso. Por favor, utiliza una clave diferente.");
        }
        else
        {
            BankDiccionary.dictionaryAccounts.Add(key, accountNew);
            Console.WriteLine("Cuenta creada exitosamente.");
            keyComplete=true;
        }
        }while(keyComplete==false);

    }

    public string login(){
         Console.WriteLine("Dime el nombre del titular");
        string holder=Console.ReadLine()!.ToUpper();
        Console.WriteLine("Clave de la cuenta");
        string key=Console.ReadLine()!;

    // Verificar si el nombre del titular coincide
    if (BankDiccionary.dictionaryAccounts.ContainsKey(key) && BankDiccionary.dictionaryAccounts[key].Owner == holder){
        Console.WriteLine("El nombre del titular coincide con la cuenta.");
        return key;
        
    }else{
        Console.WriteLine("ERROR");
       return null!;
    }
    }
}