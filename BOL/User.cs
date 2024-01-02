namespace BOL;


public  class User{
    public int Id{get;set;}
    public string Username{get;set;}
    public string Emailid{get;set;}
    public string Phone{get;set;}
    public string Password{get;set;}
public User(){
    
}

    public User(int id,string username,string emailid,string phone,string password){
        this.Id=id;
        
        this.Username=username;
        this.Emailid=emailid;
        this.Phone=phone;
        this.Password=password;
    }

public override string ToString(){
    return "(Id :"+Id+"Username : "+Username+"Emailid : "+Emailid+"Phone : "+Phone+"Password :"+Password+")";

}
}