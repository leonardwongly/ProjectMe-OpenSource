using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for courses
/// </summary>
public class courses
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _coursesID;
    private string _chipName;

    public courses(int coursesID, string chipName)
    {
        _coursesID = coursesID;
        _chipName = chipName;
    }

    public courses(string chipName)
    {
        _chipName = chipName;
    }

    public courses()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CoursesID
    {
        get { return _coursesID; }
        set { _coursesID = value; }
    }

    public string ChipName
    {
        get { return _chipName; }
        set { _chipName = value; }
    }

    public int coursesInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO courses(chipName)values(@chipName)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@chipName", this._chipName);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public courses getCourses(int coursesID)
    {
        courses coursesDetail = null;
        string chipName;
        string queryStr = "SELECT * FROM courses WHERE coursesID = @coursesID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@coursesID", coursesID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            chipName = dr["chipName"].ToString();
            coursesDetail = new courses(coursesID, chipName);
        }

        else
        {
            coursesDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return coursesDetail;
    }

    public List<courses> getCoursesAll()
    {
        List<courses> coursesList = new List<courses>();
        courses coursesDetail = null;
        string chipName;
        int coursesID;
        string queryStr = "SELECT * FROM courses ORDER BY coursesID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            coursesID = int.Parse(dr["coursesID"].ToString());
            chipName = dr["chipName"].ToString();
            coursesDetail = new courses(coursesID, chipName);
            coursesList.Add(coursesDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return coursesList;

    }

    public int coursesUpdate(int coursesID, string chipName)
    {
        string queryStr = "UPDATE courses SET" +
        " chipName = @chipName " +
        " WHERE coursesID = @coursesID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@coursesID", coursesID);
        cmd.Parameters.AddWithValue("@chipName", chipName);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int coursesDelete(int coursesID)
    {
        string queryStr = "DELETE FROM courses WHERE coursesID=@coursesID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@coursesID", coursesID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}