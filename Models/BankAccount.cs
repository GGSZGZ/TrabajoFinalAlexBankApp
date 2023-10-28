namespace Models;
using System.Text.Json;

using System.Text;

public class BankAccount{
//puedo personalizar si quiero el get o set private solo
// public int numerico {get;private set;}

    
    public int numerico {get;set;}
    public string? Number{get;set;}
    public string? Owner{get;set;}

//crea el balance 
    public decimal Balance{
        get{
            decimal balance=0;
            foreach (Transaction item in transactions)
            {
                balance+=item.Amount;
            }
            return balance;
        }
    }
    //static los objetos de la misma clase comparten este mismo objeto
    private static int accountNumber_seed=1000;

    private List<Transaction>transactions=new List<Transaction>();

public BankAccount(){

}
 public BankAccount(string owner){
        this.Owner=owner;
        this.Number=accountNumber_seed.ToString();   
        accountNumber_seed++;    
        //this.Balance=0; 

    }
    public BankAccount(string owner,decimal balance=0){
        this.Owner=owner;

        accountNumber_seed++;
        this.Number="1";
        MakeDeposit(balance,DateTime.Now,"First deposit");
        //this.Balance=balance;
    }
    public void MakeDeposit(decimal amount,DateTime date,string note,bool ingresaNegativo=false){
        if(amount<0 && ingresaNegativo==false)return;
        // if(amount<=0) throw new ArgumentOutOfRangeException(nameof(amount),"Fuera de rango, negativos invalidos");

        // DateTime customDate= new DateTime(2023,10,23,18,26,0);
        // if(date>DateTime.Now){
        //     throw new InvalidDataException("Fecha no puede ser posterior a la actual");
        // }
        // if(date<DateTime.Now){
        //     throw new InvalidDataException("Fecha no puede ser anterior a la actual");
        // }

        var deposit=new Transaction(amount,date,note);
        transactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount,DateTime date,string note){
        //no puedo sacar dinero negarivo
    // if(amount<=0) throw new ArgumentOutOfRangeException(nameof(amount),"Fuera de rango, negativos invalidos");
    //si me quedo a menos que 0 en la cuenta no puedo sacar dinero
    // if((Balance -amount )<0){
    //     throw new InvalidOperationException("No puedes sacar dinero de donde no hay");
    // }
        var deposit=new Transaction(-amount,date,note);
        transactions.Add(deposit);

    }



    public override string ToString(){
        //si no tiene nada devuelve null 
        return Owner ?? "No Owner";


        
    }

    // public string GetAccountHistory(){
    //     var history=new StringBuilder();
    //     decimal balance=0;
    //     history.AppendLine("Date\t\tAmount\tBalance\tNote");
    //     foreach (var item in transactions){
    //         balance+=item.Amount;
    //         history.AppendLine($"{item.Date.ToShortTimeString()}\t\t{item.Amount}\t{balance}\t{item.Note}");
    //     }        
    //     return history.ToString();
    // }

     public void writeJsonHistory(){
    
        //to a json with the owner's name
        string fileName = Path.filePath + Owner + ".json"; 
        string jsonString = JsonSerializer.Serialize(transactions);
        File.WriteAllText(fileName, jsonString);
        
    }

     public void readJsonHistory(){
        //read the json
            
            string jsonString = File.ReadAllText(Path.filePath + Owner + ".json");

                
                // Realizar la deserialización del JSON a mi modelo transacciones
            
              
                var historyJson = JsonSerializer.Deserialize<Transaction[]>(jsonString);


        decimal balance=0;
        Console.WriteLine("Date\tAmount\tBalance\tNote");
        
        foreach (var item in historyJson!){
            balance+=item.Amount;
            Console.WriteLine($"{item.Date.ToShortTimeString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }         
    }
    //virtual me permite hacer override
public virtual void PerformMonthlyOperation (){

}    

public virtual void PerformMonthlyDiscount (){

} 
}


