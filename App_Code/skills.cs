using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for skills
/// </summary>
public class skills
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _skillsID;
    private string _chipColour, _chipName, _textColour;

    public skills(int skillsID, string chipColour, string chipName, string textColour)
    {
        _skillsID = skillsID;
        _chipColour = chipColour;
        _chipName = chipName;
        _textColour = textColour;
    }

    public skills(string chipColour, string chipName, string textColour)
    {
        _chipColour = chipColour;
        _chipName = chipName;
        _textColour = textColour;
    }

    public skills()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int SkillsID
    {
        get { return _skillsID; }
        set { _skillsID = value; }
    }

    public string ChipColour
    {
        get { return _chipColour; }
        set { _chipColour = value; }
    }

    public string ChipName
    {
        get { return _chipName; }
        set { _chipName = value; }
    }

    public string TextColour
    {
        get { return _textColour; }
        set { _textColour = value; }
    }

    public int skillsInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO skills(chipColour, chipName, textColour)values(@chipColour, @chipName, @textColour)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@chipColour", this._chipColour);
        cmd.Parameters.AddWithValue("@chipName", this._chipName);
        cmd.Parameters.AddWithValue("@textColour", this._textColour);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public skills getSkills(int skillsID)
    {
        skills skillsDetail = null;
        string chipColour, chipName, textColour;
        string queryStr = "SELECT * FROM skills WHERE skillsID = @skillsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@skillsID", skillsID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            chipName = dr["chipName"].ToString();
            chipColour = dr["chipColour"].ToString();
            textColour = dr["textColour"].ToString();
            skillsDetail = new skills(skillsID, chipColour,chipName,textColour);
        }

        else
        {
            skillsDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return skillsDetail;
    }

    public List<skills> getSkillsAll()
    {
        List<skills> skillsList = new List<skills>();
        skills skillsDetail = null;
        string chipColour, chipName, textColour;
        int skillsID;
        string queryStr = "SELECT * FROM skills ORDER BY skillsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            skillsID = int.Parse(dr["skillsID"].ToString());
            chipColour = dr["chipColour"].ToString();
            chipName = dr["chipName"].ToString();
            textColour = dr["textColour"].ToString();
            skillsDetail = new skills(skillsID, chipColour, chipName,textColour);
            skillsList.Add(skillsDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return skillsList;

    }

    public int skillsUpdate(int skillsID, string chipColour, string chipName, string textColour)
    {
        string queryStr = "UPDATE skills SET" +
        " chipColour = @chipColour, " +
        " chipName = @chipName, " +
        " textColour = @textColour" +
        " WHERE skillsID = @skillsID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@skillsID", skillsID);
        cmd.Parameters.AddWithValue("@chipColour", chipColour);
        cmd.Parameters.AddWithValue("@chipName", chipName);
        cmd.Parameters.AddWithValue("@textColour", textColour);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int SkillsDelete(int skillsID)
    {
        string queryStr = "DELETE FROM skills WHERE skillsID=@skillsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@skillsID", skillsID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}