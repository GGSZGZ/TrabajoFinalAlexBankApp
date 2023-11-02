public class MainMenu
{
    public static void BeginMenu()
    {
        //no puedo llamar metodos no estaticos dentro de uno estatico por ello me creo un objeto de la propia clase
        MainMenu menu = new MainMenu();
        BasicBankOperations account = new BasicBankOperations();
        Credentials credentials= new Credentials();
        int option = 0;
        int secondOption=0;
        string key="";

        do
        {
            ShowMenu();
            option = ReadOption();

            switch (option)
            {
                case 1:
                    credentials.createAccount();
                    break;
                case 2:
                
                   key= credentials.login();
                    
                if(key==null){
                    break;
                }
                   account.writeHistory(key);
                   do{
                    ShowSecondMenu();
                    secondOption = ReadSecondOption();
                    menu.BankMenu(secondOption,key);
                   }while(secondOption!=4);
                    break;
               
            }
        } while (option != 3);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("1-Crear cuenta");
        Console.WriteLine("2-Iniciar sesión");
        Console.WriteLine("3-Salir");
         Console.WriteLine("Elige una opción: ");
        
    }
    private static void ShowSecondMenu()
    {
        Console.WriteLine("1-Ingresar dinero");
        Console.WriteLine("2-Sacar dinero");
        Console.WriteLine("3-Listado de operaciones");
        Console.WriteLine("4-Salir");
         Console.WriteLine("Elige una opción: ");
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
                    Console.WriteLine("Debes introducir valores comprendidos entre 1 y 3");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Debes introducir valores numéricos");
            }catch(ArgumentNullException){
                Console.WriteLine("Valor nulo inválido");
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
                if (option <= 0 || option > 4)
                {
                    Console.WriteLine("Debes introducir valores comprendidos entre 1 y 4");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Debes introducir valores numéricos");
            }
        } while (true);

        return option;
    }


    public void BankMenu(int secondOption,string key){
        BasicBankOperations operatingAccount= new BasicBankOperations();
        switch (secondOption)
            {
                case 1:
                operatingAccount.depositMoney(key);
                //cada operacion la guardo en el json
                operatingAccount.writeHistory(key);
                    break;
                case 2:
                operatingAccount.withDrawal(key);
                operatingAccount.writeHistory(key);
                    break;
                case 3:
                //    operatingAccount.operationHistory(key);
                   operatingAccount.readHistory(key);
                    break;
                
               
            }
    }
}