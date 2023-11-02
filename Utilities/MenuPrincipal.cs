public class MenuPrincipal
{
    public static void IniciarMenu()
    {
        //no puedo llamar metodos no estaticos dentro de uno estatico por ello me creo un objeto de la propia clase
        MenuPrincipal menu = new MenuPrincipal();
        GenericCode cuenta = new GenericCode();
        Credentials credentials= new Credentials();
        int opcion = 0;
        int segundaOpcion=0;
        string key="";

        do
        {
            MostrarMenu();
            opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    credentials.createAccount();
                    break;
                case 2:
                
                   key= credentials.login();
                    
                if(key==null){
                    break;
                }
                   cuenta.writeHistory(key);
                   do{
                    mostrarSegundoMenu();
                    segundaOpcion = leerSegundaOpcion();
                    menu.menuBancario(segundaOpcion,key);
                   }while(segundaOpcion!=4);
                    break;
               
            }
        } while (opcion != 3);
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("1-Crear cuenta");
        Console.WriteLine("2-Iniciar sesión");
        Console.WriteLine("3-Salir");
         Console.WriteLine("Elige una opción: ");
        
    }
    private static void mostrarSegundoMenu()
    {
        Console.WriteLine("1-Ingresar dinero");
        Console.WriteLine("2-Sacar dinero");
        Console.WriteLine("3-Listado de operaciones");
        Console.WriteLine("4-Salir");
         Console.WriteLine("Elige una opción: ");
    }

    private static int LeerOpcion()
    {
        int opcion;
        do
        {
            try
            {
               
                opcion = int.Parse(Console.ReadLine()!);
                if (opcion <= 0 || opcion > 3)
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

        return opcion;
    }


     private static int leerSegundaOpcion()
    {
        int opcion;
               
        do
        {
            try
            {
                opcion = int.Parse(Console.ReadLine()!);
                if (opcion <= 0 || opcion > 4)
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

        return opcion;
    }


    public void menuBancario(int segundaOpcion,string key){
        GenericCode operatingAccount= new GenericCode();
        switch (segundaOpcion)
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