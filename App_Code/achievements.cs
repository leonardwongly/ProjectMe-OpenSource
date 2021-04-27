using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for honorsAwardsCertifications
/// </summary>
public class achievements
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _achievementsID;
    private string _achievementsName, _modalID,  _modalImage,  _modalDesc;

    public achievements(int achievementsID, string achievementsName, string modalID, string modalImage, string modalDesc)
    {
        _achievementsID = achievementsID;
        _achievementsName = achievementsName;
        _modalID = modalID;
        _modalImage = modalImage;
        _modalDesc = modalDesc;
    }

    public achievements(string achievementsName, string modalID, string modalImage, string modalDesc)
    {
        _achievementsName = achievementsName;
        _modalID = modalID;
        _modalImage = modalImage;
        _modalDesc = modalDesc;
    }

    public achievements()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int AchievementsID
    {
        get { return _achievementsID; }
        set { _achievementsID = value; }
    }

    public string AchievementsName
    {
        get { return _achievementsName; }
        set { _achievementsName = value; }
    }

    public string ModalID
    {
        get { return _modalID; }
        set { _modalID = value; }
    }

    public string ModalImage
    {
        get { return _modalImage; }
        set { _modalImage = value; }
    }

    public string ModalDesc
    {
        get { return _modalDesc; }
        set { _modalDesc = value; }
    }

    public int achievementsInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO achievements(achievementsName," +
                          "modalID,modalImage,modalDesc)values(@achievementsName,@modalID,@modalImage,@modalDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@achievementsName", this._achievementsName);
        cmd.Parameters.AddWithValue("@modalID", this._modalID);
        cmd.Parameters.AddWithValue("@modalImage", this._modalImage);
        cmd.Parameters.AddWithValue("@modalDesc", this._modalDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public achievements getAchievements(int achievementsID)
    {
        achievements achievementsDetail = null;
        string achievementsName, modalID, modalImage, modalDesc;
        string queryStr = "SELECT * FROM achievements WHERE achievementsID = @achievementsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@achievementsID", achievementsID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            achievementsName = dr["achievementsName"].ToString();
            modalID = dr["modalID"].ToString();
            modalImage = dr["modalImage"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            achievementsDetail = new achievements(achievementsID, achievementsName,
                                                  modalID, modalImage, modalDesc);
        }

        else
        {
            achievementsDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return achievementsDetail;
    }

    public List<achievements> getAchievementsAll()
    {
        List<achievements> achievementsList = new List<achievements>();
        achievements achievementsDetail = null;
        string achievementsName, modalID,  modalImage, modalDesc;
        int achievementsID;
        string queryStr = "SELECT * FROM achievements ORDER BY achievementsID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            achievementsID = int.Parse(dr["achievementsID"].ToString());
            achievementsName = dr["achievementsName"].ToString();
            modalID = dr["modalID"].ToString();
            modalImage = dr["modalImage"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            achievementsDetail = new achievements(achievementsID, achievementsName,
                                                   modalID, modalImage, modalDesc);
            achievementsList.Add(achievementsDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return achievementsList;

    }

    public int achievementsUpdate(int achievementsID, string achievementsName, string modalID,
                               string modalImage,  string modalDesc)
    {
        string queryStr = "UPDATE achievements SET" +
        " achievementsName = @achievementsName, " +
        " modalID = @modalID," +
        " modalImage = @modalImage," +
        " modalDesc = @modalDesc" +
        " WHERE achievementsID = @achievementsID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@achievementsID", achievementsID);
        cmd.Parameters.AddWithValue("@achievementsName", achievementsName);
        cmd.Parameters.AddWithValue("@modalID", modalID);
        cmd.Parameters.AddWithValue("@modalImage", modalImage);
        cmd.Parameters.AddWithValue("@modalDesc", modalDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int achievementsDelete(int achievementsID)
    {
        string queryStr = "DELETE FROM achievements WHERE achievementsID=@achievementsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@achievementsID", achievementsID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}