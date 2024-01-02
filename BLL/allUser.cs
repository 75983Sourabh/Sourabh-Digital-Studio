namespace BLL;
using BOL;
using DAL;
using System.Collections.Generic;

public class allUser
{
    public List<User> GetallUList()
    {
        List<User> allUser = new List<User>();
        allUser = DBManager.GetallUList();
        return allUser;
    }
}