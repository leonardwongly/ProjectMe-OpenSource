using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for volunteer
/// </summary>
public class volunteer
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _volunteerID;
    private string _volunteerName, _volunteerDesc, _volunteerImage, _volunteerBadge, _modalID,  _modalDesc;

    public volunteer(int volunteerID, string volunteerName, string volunteerDesc,
                     string volunteerImage, string volunteerBadge, string modalID,string modalDesc)
    {
        _volunteerID = volunteerID;
        _volunteerName = volunteerName;
        _volunteerDesc = volunteerDesc;
        _volunteerImage = volunteerImage;
        _volunteerBadge = volunteerBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }
    public volunteer(string volunteerName, string volunteerDesc,
                     string volunteerImage, string volunteerBadge, string modalID, string modalDesc)
    {
        _volunteerName = volunteerName;
        _volunteerDesc = volunteerDesc;
        _volunteerImage = volunteerImage;
        _volunteerBadge = volunteerBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }

    public volunteer()
    {
        
    }

    public int VolunteerID
    {
        get { return _volunteerID; }
        set { _volunteerID = value; }
    }

    public string VolunteerName
    {
        get { return _volunteerName; }
        set { _volunteerName = value; }
    }

    public string VolunteerDesc
    {
        get { return _volunteerDesc; }
        set { _volunteerDesc = value; }
    }

    public string VolunteerImage
    {
        get { return _volunteerImage; }
        set { _volunteerImage = value; }
    }

    public string VolunteerBadge
    {
        get { return _volunteerBadge; }
        set { _volunteerBadge = value; }
    }

    public string ModalID
    {
        get { return _modalID; }
        set { _modalID = value; }
    }

    public string ModalDesc
    {
        get { return _modalDesc; }
        set { _modalDesc = value; }
    }

    public int volunteerInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO volunteer(volunteerName,volunteerDesc,volunteerImage,volunteerBadge,"
                        + "modalID,modalDesc)values(@volunteerName,@volunteerDesc,@volunteerImage," 
                        + "@volunteerBadge,@modalID,@modalDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@volunteerName", this._volunteerName);
        cmd.Parameters.AddWithValue("@volunteerDesc", this._volunteerDesc);
        cmd.Parameters.AddWithValue("@volunteerImage", this._volunteerImage);
        cmd.Parameters.AddWithValue("@volunteerBadge", this._volunteerBadge);
        cmd.Parameters.AddWithValue("@modalID", this._modalID);
        cmd.Parameters.AddWithValue("@modalDesc", this._modalDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public volunteer getVolunteer(int volunteerID)
    {
        volunteer volunteerDetail = null;
        string volunteerName, volunteerDesc, volunteerImage, volunteerBadge;
        string modalID,  modalDesc;
        string queryStr = "SELECT * FROM volunteer WHERE volunteerID = @volunteerID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@volunteerID", volunteerID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            volunteerName = dr["volunteerName"].ToString();
            volunteerDesc = dr["volunteerDesc"].ToString();
            volunteerImage = dr["volunteerImage"].ToString();
            volunteerBadge = dr["volunteerBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            volunteerDetail = new volunteer(volunteerID, volunteerName, volunteerDesc,
                                          volunteerImage, volunteerBadge, modalID, modalDesc);
        }

        else
        {
            volunteerDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return volunteerDetail;
    }

    public List<volunteer> getVolunteerAll()
    {
        List<volunteer> volunteerList = new List<volunteer>();
        volunteer volunteerDetail = null;
        string volunteerName, volunteerDesc, volunteerImage, volunteerBadge;
        string modalID, modalDesc;
        int volunteerID;
        string queryStr = "SELECT * FROM volunteer ORDER BY volunteerID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            volunteerID = int.Parse(dr["volunteerID"].ToString());
            volunteerName = dr["volunteerName"].ToString();
            volunteerDesc = dr["volunteerDesc"].ToString();
            volunteerImage = dr["volunteerImage"].ToString();
            volunteerBadge = dr["volunteerBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            volunteerDetail = new volunteer(volunteerID, volunteerName, volunteerDesc,
                                          volunteerImage, volunteerBadge, modalID, modalDesc);
            volunteerList.Add(volunteerDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return volunteerList;

    }

    public int volunteerUpdate(int volunteerID, string volunteerName, string volunteerDesc,
                               string volunteerImage, string volunteerBadge, string modalID, string modalDesc)
    {
        string queryStr = "UPDATE volunteer SET" +
        " volunteerName = @volunteerName, " +
        " volunteerDesc = @volunteerDesc, " +
        " volunteerImage = @volunteerImage, " +
        " volunteerBadge = @volunteerBadge, " +
        " modalID = @modalID," +
        " modalDesc = @modalDesc" +
        " WHERE volunteerID = @volunteerID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@volunteerID", volunteerID);
        cmd.Parameters.AddWithValue("@volunteerName", volunteerName);
        cmd.Parameters.AddWithValue("@volunteerDesc", volunteerDesc);
        cmd.Parameters.AddWithValue("@volunteerImage", volunteerImage);
        cmd.Parameters.AddWithValue("@volunteerBadge", volunteerBadge);
        cmd.Parameters.AddWithValue("@modalID", modalID);
        cmd.Parameters.AddWithValue("@modalDesc", modalDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int volunteerDelete(int volunteerID)
    {
        string queryStr = "DELETE FROM volunteer WHERE volunteerID=@volunteerID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@volunteerID", volunteerID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

}