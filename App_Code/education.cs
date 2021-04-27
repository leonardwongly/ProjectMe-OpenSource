using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for education
/// </summary>
public class education
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _educationID;
    private string _educationName, _educationDesc, _educationImage, _educationBadge;

    public int educationInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO education(educationName,educationDesc,educationImage,educationBadge) values(@educationName,@educationDesc,@educationImage,@educationBadge)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@educationName", this._educationName);
        cmd.Parameters.AddWithValue("@educationDesc", this._educationDesc);
        cmd.Parameters.AddWithValue("@educationImage", this._educationImage);
        cmd.Parameters.AddWithValue("@educationBadge", this._educationBadge);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public int educationUpdate(int educationID, string educationName, string educationDesc, string educationImage, string educationBadge)
    {
        string queryStr = "UPDATE education SET" +
        " educationName = @educationName, " +
        " educationDesc = @educationDesc, " +
        " educationImage = @educationImage, " +
        " educationBadge = @educationBadge " +
        " WHERE educationID = @educationID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@educationID", educationID);
        cmd.Parameters.AddWithValue("@educationName", educationName);
        cmd.Parameters.AddWithValue("@educationDesc", educationDesc);
        cmd.Parameters.AddWithValue("@educationImage", educationImage);
        cmd.Parameters.AddWithValue("@educationBadge", educationBadge);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int educationDelete(int educationID)
    {
        string queryStr = "DELETE FROM education WHERE educationID=@educationID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@educationID", educationID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public education getEducation(int educationID)
    {
        education educationDetail = null;
        string educationName, educationDesc, educationImage, educationBadge;
        string queryStr = "SELECT * FROM education WHERE educationID = @educationID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@educationID", educationID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            educationName = dr["educationName"].ToString();
            educationDesc = dr["educationDesc"].ToString();
            educationImage = dr["educationImage"].ToString();
            educationBadge = dr["educationBadge"].ToString();
            educationDetail = new education(educationID, educationName, educationDesc, educationImage, educationBadge);
        }

        else
        {
            educationDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return educationDetail;
    }

    public List<education> getEducationAll()
    {
        List<education> educationList = new List<education>();
        string educationName, educationDesc, educationImage, educationBadge;
        int educationID;
        string queryStr = "SELECT * FROM education ORDER BY educationID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            educationID = int.Parse(dr["educationID"].ToString());
            educationName = dr["educationName"].ToString();
            educationDesc = dr["educationDesc"].ToString();
            educationImage = dr["educationImage"].ToString();
            educationBadge = dr["educationBadge"].ToString();
            education e = new education(educationID, educationName, educationDesc, educationImage, educationBadge);
            educationList.Add(e);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return educationList;
    }

    public education(int educationID, string educationName, string educationDesc, string educationImage, string educationBadge)
    {
        _educationID = educationID;
        _educationName = educationName;
        _educationDesc = educationDesc;
        _educationImage = educationImage;
        _educationBadge = educationBadge;
    }

    public education(string educationName, string educationDesc, string educationImage, string educationBadge)
    {
        _educationName = educationName;
        _educationDesc = educationDesc;
        _educationImage = educationImage;
        _educationBadge = educationBadge;
    }

    public education()
    {
       
    }

    public int EducationID
    {
        get { return _educationID; }
        set { _educationID = value; }
    }

    public string EducationName
    {
        get { return _educationName; }
        set { _educationName = value; }
    }

    public string EducationDesc
    {
        get { return _educationDesc; }
        set { _educationDesc = value; }
    }

    public string EducationImage
    {
        get { return _educationImage; }
        set { _educationImage = value; }
    }
    
    public string EducationBadge
    {
        get { return _educationBadge; }
        set { _educationBadge = value; }
    }
}