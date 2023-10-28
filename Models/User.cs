namespace Models;

public class User{


    public string? Name {get;set;}
    public string? Lastname {get;set;}
 

    public string? Nif {get;set;}


public User(string name,string lastname){
    Name=name;
    Lastname=lastname;
    
}

public User(){}

    public override string ToString()
    {
        //para definir valores por defecto pos si salen null
        return (Name ?? "NoName")+ " " +(Lastname ?? "NoLastName") + " " + Nif;
    }

}