using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for summary
/// </summary>
public class summary
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _summaryID;
    private string _summaryDesc;

    public summary(int summaryID, string summaryDesc)
    {
        _summaryID = summaryID;
        _summaryDesc = summaryDesc;
    }

    public summary(string summaryDesc)
    {
        _summaryDesc = summaryDesc;
    }

    public summary()
    {

    }

    public int SummaryID
    {
        get { return _summaryID; }
        set { _summaryID = value; }
    }

    public string SummaryDesc
    {
        get { return _summaryDesc; }
        set { _summaryDesc = value; }
    }

    public int summaryInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO summary(summaryDesc)values(@summaryDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@summaryDesc", this._summaryDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public summary getSummary(int summaryID)
    {
        summary summaryDetail = null;
        string summaryDesc;
        string queryStr = "SELECT * FROM summary WHERE summaryID = @summaryID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@summaryID", summaryID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            summaryDesc = dr["summaryDesc"].ToString();
            summaryDetail = new summary(summaryID, summaryDesc);
        }

        else
        {
            summaryDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return summaryDetail;
    }

    public List<summary> getSummaryAll()
    {
        List<summary> summaryList = new List<summary>();
        string summaryDesc;
        int summaryID;
        string queryStr = "SELECT * FROM summary";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            summaryID = int.Parse(dr["summaryID"].ToString());
            summaryDesc = dr["summaryDesc"].ToString();
            summary a = new summary(summaryID,summaryDesc);
            summaryList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return summaryList;
    }

    public int summaryUpdate(int summaryID, string summaryDesc)
    {
        string queryStr = "UPDATE summary SET" +
        " summaryDesc = @summaryDesc " +
        " WHERE summaryID = @summaryID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@summaryID", summaryID);
        cmd.Parameters.AddWithValue("@summaryDesc", summaryDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int SummaryDelete(int summaryID)
    {
        string queryStr = "DELETE FROM summary WHERE summaryID=@summaryID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@summaryID", summaryID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}