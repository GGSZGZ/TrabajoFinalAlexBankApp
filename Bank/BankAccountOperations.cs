namespace Models;
using System.Text.Json;

using System.Text;

public class BankAccount{
//puedo personalizar si quiero el get o set private solo
// public int numerico {get;private set;}

    
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

    private List<Transaction>transactions=new List<Transaction>();

public BankAccount(){

}
 public BankAccount(string owner){
        this.Owner=owner;
    }
    public BankAccount(string owner,decimal balance=0){
        this.Owner=owner;
        this.Number="1";
        MakeDeposit(balance,DateTime.Now,"First deposit");
    }
    public void MakeDeposit(decimal amount,DateTime date,string note,bool negativeIncome=false){
        if(amount<0 && negativeIncome==false)return;
        var deposit=new Transaction(amount,date,note);
        transactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount,DateTime date,string note){

        var deposit=new Transaction(-amount,date,note);
        transactions.Add(deposit);

    }

     public void writeJsonHistory(){
    
        //to a json with the owner's name
        string fileName = Path.filePath + Owner + ".json"; 
        string jsonString = JsonSerializer.Serialize(transactions);
        File.WriteAllText(fileName, jsonString);
        
    }

     public void readJsonHistory(){

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


