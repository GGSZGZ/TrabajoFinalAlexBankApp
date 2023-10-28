//cobre intereses del total que debo mensuales del total que debo
namespace Models;

public class CreditCardAccount : BankAccount{

private decimal interestRate=0.05M;


public CreditCardAccount(string name,decimal initialBalance) : base(name,initialBalance){
    
}


    public override void PerformMonthlyDiscount()
    {
        //calculo de mi total con el ratio de interest y lo deposito en la cuenta, que lo sumara al total
        if(Balance<0){
        bool ingresaNegativo=true;
        decimal interest=Balance*interestRate;
        MakeDeposit(interest,DateTime.Now.AddDays(30),"Monthly Discount",ingresaNegativo);
        }
    }
}