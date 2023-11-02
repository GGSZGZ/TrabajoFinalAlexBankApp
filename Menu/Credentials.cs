using System;
using Models;

public class Credentials{
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
          if (BankDiccionary.diccionarioCuentas.ContainsKey(clave))
        {
            Console.WriteLine("La clave ya está en uso. Por favor, utiliza una clave diferente.");
        }
        else
        {
            BankDiccionary.diccionarioCuentas.Add(clave, accountNew);
            Console.WriteLine("Cuenta creada exitosamente.");
            keyComplete=true;
        }
        }while(keyComplete==false);

    }

    public string login(){
         Console.WriteLine("Dime el nombre del titular");
        string titular=Console.ReadLine()!.ToUpper();
        Console.WriteLine("Clave de la cuenta");
        string key=Console.ReadLine()!;

    // Verificar si el nombre del titular coincide
    if (BankDiccionary.diccionarioCuentas.ContainsKey(key) && BankDiccionary.diccionarioCuentas[key].Owner == titular){
        Console.WriteLine("El nombre del titular coincide con la cuenta.");
        return key;
        
    }else{
        Console.WriteLine("ERROR");
       return null!;
    }
    }
}