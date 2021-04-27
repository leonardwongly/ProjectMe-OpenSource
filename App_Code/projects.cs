using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for projects
/// </summary>
public class projects
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _projectsID;
    private string _projectsName, _modalID,  _modalImage,  _modalDesc, _firstColour, _secondColour;

    public projects(int projectsID, string projectsName, string modalID, string modalImage, string modalDesc, string firstColour, string secondColour)
    {
        _projectsID = projectsID;
        _projectsName = projectsName;
        _modalID = modalID;
        _modalImage = modalImage;
        _modalDesc = modalDesc;
        _firstColour = firstColour;
        _secondColour = secondColour;
    }

    public projects(string projectsName, string modalID, string modalImage, string modalDesc, string firstColour, string secondColour)
    {
        _projectsName = projectsName;
        _modalID = modalID;
        _modalImage = modalImage;
        _modalDesc = modalDesc;
        _firstColour = firstColour;
        _secondColour = secondColour;
    }

    public projects()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ProjectsID
    {
        get { return _projectsID; }
        set { _projectsID = value; }
    }

    public string ProjectsName
    {
        get { return _projectsName; }
        set { _projectsName = value; }
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

    public string FirstColour
    {
        get { return _firstColour; }
        set { _firstColour = value; }
    }

    public string SecondColour
    {
        get { return _secondColour; }
        set { _secondColour = value; }
    }

    public int projectsInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO projects(projectsName,modalID,modalImage," + 
                          "modalDesc,firstColour,secondColour)values(@projectsName,@modalID,@modalImage,@modalDesc,@firstColour,@secondColour)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@projectsName", this._projectsName);
        cmd.Parameters.AddWithValue("@modalID", this._modalID);
        cmd.Parameters.AddWithValue("@modalImage", this._modalImage);
        cmd.Parameters.AddWithValue("@modalDesc", this._modalDesc);
        cmd.Parameters.AddWithValue("@firstColour", this._firstColour);
        cmd.Parameters.AddWithValue("@secondColour", this._secondColour);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public projects getProjects(int projectsID)
    {
        projects projectsDetail = null;
        string projectsName, modalID,  modalImage, modalDesc, firstColour, secondColour;
        string queryStr = "SELECT * FROM projects WHERE projectsID = @projectsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@projectsID", projectsID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        { 
            projectsName = dr["projectsName"].ToString();
            modalID = dr["modalID"].ToString();
            modalImage = dr["modalImage"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            firstColour = dr["firstColour"].ToString();
            secondColour = dr["secondColour"].ToString();
            projectsDetail = new projects(projectsID, projectsName, modalID,  modalImage, modalDesc, firstColour, secondColour);
        }

        else
        {
            projectsDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return projectsDetail;
    }

    public List<projects> getProjectsAll()
    {
        List<projects> projectsList = new List<projects>();
        projects projectsDetail = null;
        string projectsName, modalID, modalImage, modalDesc, firstColour, secondColour;
        int projectsID;
        string queryStr = "SELECT * FROM projects ORDER BY projectsID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            projectsID = int.Parse(dr["projectsID"].ToString());
            projectsName = dr["projectsName"].ToString();
            modalID = dr["modalID"].ToString();
            modalImage = dr["modalImage"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            firstColour = dr["firstColour"].ToString();
            secondColour = dr["secondColour"].ToString();
            projectsDetail = new projects(projectsID, projectsName, modalID, modalImage, modalDesc, firstColour, secondColour);
            projectsList.Add(projectsDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return projectsList;

    }

    public int projectsUpdate(int projectsID, string projectsName, string modalID, string modalImage, string modalDesc, string firstColour, string secondColour)
    {
        string queryStr = "UPDATE projects SET" +
        " projectsName = @projectsName, " +
        " modalID = @modalID," +
        " modalImage = @modalImage," +
        " modalDesc = @modalDesc" +
        " firstColour = @firstColour" +
        " secondColour = @secondColour" +
        " WHERE projectsID = @projectsID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@projectsID", projectsID);
        cmd.Parameters.AddWithValue("@projectsName", projectsName);
        cmd.Parameters.AddWithValue("@modalID", modalID);
        cmd.Parameters.AddWithValue("@modalImage", modalImage);
        cmd.Parameters.AddWithValue("@modalDesc", modalDesc);
        cmd.Parameters.AddWithValue("@firstColour", firstColour);
        cmd.Parameters.AddWithValue("@secondColour", secondColour);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int projectsDelete(int projectsID)
    {
        string queryStr = "DELETE FROM projects WHERE projectsID=@projectsID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@projectsID", projectsID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}