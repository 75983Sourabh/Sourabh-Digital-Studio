namespace DAL;
using BOL;
using System.Linq.Expressions;

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Ocsp;

public  class DBManager
{
    public static string conString = @"server=localhost;port=3306;user=root;password=Shivani@123;database=sourabh";

    public static List<User> GetallUList()
    {
        List<User> allUser = new List<User>();



        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;
        string query = "select * from User";

        try
        {
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string username = reader["Username"].ToString();
                string email = reader["Emailid"].ToString();
                string phone = reader["Phone"].ToString();
                string password = reader["Password"].ToString();


                User u = new User
                {
                    Id = id,
                    Username = username,
                    Emailid = email,
                    Phone = phone,
                    Password = password



                };
                allUser.Add(u);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        finally
        {
            conn.Close();
        }
        return allUser;
    }
    public static void insertData(User u)
    {
       // bool status = false;
        string query = "insert into User values(@Id,@Username,@Emailid,@Phone,@Password)";
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = conString;
        MySqlCommand command=new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@Id", u.Id);
        command.Parameters.AddWithValue("@Username", u.Username);
        command.Parameters.AddWithValue("@Emailid", u.Emailid);
        command.Parameters.AddWithValue("@Phone", u.Phone);
        command.Parameters.AddWithValue("@Password", u.Password);

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
           // status = true;    

        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        finally{
            conn.Close();
        }
        // return status;



    }
   
public static void UpdateData(User u){
    string query ="update User set Username=@Username,Password=@Password where Emailid=@Emailid";
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
    MySqlCommand command=new MySqlCommand(query,con);
    command.Parameters.AddWithValue("@Username",u.Username);
    command.Parameters.AddWithValue("@Password",u.Password);
    command.Parameters.AddWithValue("@Emailid",u.Emailid);

try
{
    con.Open();
    command.ExecuteNonQuery();
}
catch (System.Exception e)
{
    System.Console.WriteLine(e.Message);
    
    throw;
}
finally{
    con.Close();

}


}
public static void deleteData(string Emailid){
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=conString;
    string query="delete from User where Emailid=@Emailid";
    MySqlCommand command=new MySqlCommand(query,con);
    command.Parameters.AddWithValue("@Emailid", Emailid);
    try
    {
        con.Open();
        command.ExecuteNonQuery();


    }
    catch (System.Exception e)
    {
        System.Console.WriteLine("error Occured"+e.Message);
        throw;
    }
    finally{
        con.Close();
    }

}



}