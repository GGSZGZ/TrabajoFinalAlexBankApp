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
        var deposit=new Transaction(amount,date,note);
        transactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount,DateTime date,string note){

        var deposit=new Transaction(-amount,date,note);
        transactions.Add(deposit);

    }



    public override string ToString(){
        //si no tiene nada devuelve null 
        return Owner ?? "No Owner";
    }


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
}


