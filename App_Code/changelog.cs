using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for changelog
/// </summary>
public class changelog
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _changelogsID;
    private string _version, _changelogsDate, _changelogsDesc;

    public changelog(int changelogsID, string version, string changelogsDate,
                        string changelogsDesc)
    {
        _changelogsID = changelogsID;
        _version = version;
        _changelogsDate = changelogsDate;
        _changelogsDesc = changelogsDesc;
    }

    public changelog(string version, string changelogsDate,
                        string changelogsDesc)
    {
        _version = version;
        _changelogsDate = changelogsDate;
        _changelogsDesc = changelogsDesc;
    }

    public changelog()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ChangelogsID
    {
        get { return _changelogsID; }
        set { _changelogsID = value; }
    }

    public string Version
    {
        get { return _version; }
        set { _version = value; }
    }

    public string ChangelogsDate
    {
        get { return _changelogsDate; }
        set { _changelogsDate = value; }
    }

    public string ChangelogsDesc
    {
        get { return _changelogsDesc; }
        set { _changelogsDesc = value; }
    }

    public int changelogsInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO changelogs(" +
                          "version,changelogsDate,changelogsDesc)values(" +
                          "@version,@changelogsDate,@changelogsDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@version", this._version);
        cmd.Parameters.AddWithValue("@changelogsDate", this._changelogsDate);
        cmd.Parameters.AddWithValue("@changelogsDesc", this._changelogsDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public changelog getChangelogs(int changelogsID)
    {
        changelog changelogsDetail = null;
        string version, changelogsDate, changelogsDesc;
        string queryStr = "SELECT * FROM changelogs WHERE changelogsID = @changelogsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@changelogsID", changelogsID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            version = dr["version"].ToString();
            changelogsDate = dr["changelogsDate"].ToString();
            changelogsDesc = dr["changelogsDesc"].ToString();
            changelogsDetail = new changelog(changelogsID, version, changelogsDate, changelogsDesc);
        }

        else
        {
            changelogsDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return changelogsDetail;
    }

    public List<changelog> getChangelogsAll()
    {
        List<changelog> changelogsList = new List<changelog>();
        changelog changelogsDetail = null;
        string version, changelogsDate, changelogsDesc;
        int changelogsID;
        string queryStr = "SELECT * FROM changelogs ORDER BY changelogsID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            changelogsID = int.Parse(dr["changelogsID"].ToString());
            version = dr["version"].ToString();
            changelogsDate = dr["changelogsDate"].ToString();
            changelogsDesc = dr["changelogsDesc"].ToString();
            changelogsDetail = new changelog(changelogsID, version, changelogsDate, changelogsDesc);
            changelogsList.Add(changelogsDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return changelogsList;
    }

    public int changelogsUpdate(int changelogsID, string version, string changelogsDate, string changelogsDesc)
    {
        string queryStr = "UPDATE changelogs SET" +
        " version = @version, " +
        " changelogsDate = @changelogsDate," +
        " changelogsDesc = @changelogsDesc" +
        " WHERE changelogsID = @changelogsID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@changelogsID", changelogsID);
        cmd.Parameters.AddWithValue("@version", version);
        cmd.Parameters.AddWithValue("@changelogsDate", changelogsDate);
        cmd.Parameters.AddWithValue("@changelogsDesc", changelogsDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int changelogsDelete(int changelogsID)
    {
        string queryStr = "DELETE FROM changelogs WHERE changelogsID=@changelogsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@changelogsID", changelogsID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}