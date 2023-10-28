namespace Models;

public class InterestEarningAccount : BankAccount{

private decimal interestRate=0.05M;

//base es como el super de java para indicar la herencia
public InterestEarningAccount(string name,decimal initialBalance) : base(name,initialBalance){
    
}


//utilizo el metodo de la clase padre
    public override void PerformMonthlyOperation()
    {
        //calculo de mi total con el ratio de interest y lo deposito en la cuenta, que lo sumara al total
        decimal interestEarned=Balance*interestRate;
        MakeDeposit(interestEarned,DateTime.Now.AddDays(30),"Monthly Earnings");
    }
}