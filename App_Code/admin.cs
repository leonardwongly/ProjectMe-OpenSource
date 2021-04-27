using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for admin
/// </summary>
public class admin
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _adminID;
    private string _userName, _password;

    public admin getAccount(string userName)
    {
        admin adminDetail = null;
        string password;

        string queryStr = "SELECT * FROM admin WHERE userName = @userName";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@userName", userName);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if(dr.Read())
        {
            userName = dr["userName"].ToString();
            password = dr["password"].ToString();

            adminDetail = new admin(userName, password);
        } else
        {
            adminDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();

        return adminDetail;
    }

    public int adminRegister()
    {
        int result = 0;

        string queryStr = "INSERT INTO admin(userName, password)values(@userName,@password)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@userName", this._userName);
        cmd.Parameters.AddWithValue("@password", this._password);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public admin(int adminID, string userName, string password)
    {
        _adminID = adminID;
        _userName = userName;
        _password = password;
    }

    public admin(string userName, string password)
    {
        _userName = userName;
        _password = password;
    }

    public admin()
    {

    }

    public int AdminID
    {
        get { return _adminID; }
        set { _adminID = value; }
    }

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
}