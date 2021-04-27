using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for job
/// </summary>
public class job
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _jobID;
    private string _jobName, _jobDesc, _jobImage, _jobBadge, _modalID, _modalDesc;

    public job(int jobID, string jobName, string jobDesc,
                     string jobImage, string jobBadge, string modalID, string modalDesc)
    {
        _jobID = jobID;
        _jobName = jobName;
        _jobDesc = jobDesc;
        _jobImage = jobImage;
        _jobBadge = jobBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }

    public job(string jobName, string jobDesc,
                     string jobImage, string jobBadge, string modalID,string modalDesc)
    {
        _jobName = jobName;
        _jobDesc = jobDesc;
        _jobImage = jobImage;
        _jobBadge = jobBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }

    public job()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int JobID
    {
        get { return _jobID; }
        set { _jobID = value; }
    }

    public string JobName
    {
        get { return _jobName; }
        set { _jobName = value; }
    }

    public string JobDesc
    {
        get { return _jobDesc; }
        set { _jobDesc = value; }
    }

    public string JobImage
    {
        get { return _jobImage; }
        set { _jobImage = value; }
    }

    public string JobBadge
    {
        get { return _jobBadge; }
        set { _jobBadge = value; }
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

    public int jobInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO job(jobName,jobDesc,jobImage,jobBadge,"
                        + "modalID,modalDesc)values(@jobName,@jobDesc,@jobImage,"
                        + "@jobBadge,@modalID,@modalDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@jobName", this._jobName);
        cmd.Parameters.AddWithValue("@jobDesc", this._jobDesc);
        cmd.Parameters.AddWithValue("@jobImage", this._jobImage);
        cmd.Parameters.AddWithValue("@jobBadge", this._jobBadge);
        cmd.Parameters.AddWithValue("@modalID", this._modalID);
        cmd.Parameters.AddWithValue("@modalDesc", this._modalDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public job getJob(int jobID)
    {
        job jobDetail = null;
        string jobName, jobDesc, jobImage, jobBadge;
        string modalID, modalHeader, modalDesc;
        string queryStr = "SELECT * FROM job WHERE jobID = @jobID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@jobID", jobID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            jobName = dr["jobName"].ToString();
            jobDesc = dr["jobDesc"].ToString();
            jobImage = dr["jobImage"].ToString();
            jobBadge = dr["jobBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            jobDetail = new job(jobID, jobName, jobDesc,jobImage, jobBadge, modalID, modalDesc);
        }

        else
        {
            jobDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return jobDetail;
    }

    public List<job> getjobAll()
    {
        List<job> jobList = new List<job>();
        job jobDetail = null;
        string jobName, jobDesc, jobImage, jobBadge;
        string modalID, modalDesc;
        int jobID;
        string queryStr = "SELECT * FROM job ORDER BY jobID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            jobID = int.Parse(dr["jobID"].ToString());
            jobName = dr["jobName"].ToString();
            jobDesc = dr["jobDesc"].ToString();
            jobImage = dr["jobImage"].ToString();
            jobBadge = dr["jobBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            jobDetail = new job(jobID, jobName, jobDesc,jobImage, jobBadge, modalID, modalDesc);
            jobList.Add(jobDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return jobList;

    }

    public int jobUpdate(int jobID, string jobName, string jobDesc,
                               string jobImage, string jobBadge, string modalID, string modalDesc)
    {
        string queryStr = "UPDATE job SET" +
        " jobName = @jobName, " +
        " jobDesc = @jobDesc, " +
        " jobImage = @jobImage, " +
        " jobBadge = @jobBadge, " +
        " modalID = @modalID," +
        " modalDesc = @modalDesc" +
        " WHERE jobID = @jobID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@jobID", jobID);
        cmd.Parameters.AddWithValue("@jobName", jobName);
        cmd.Parameters.AddWithValue("@jobDesc", jobDesc);
        cmd.Parameters.AddWithValue("@jobImage", jobImage);
        cmd.Parameters.AddWithValue("@jobBadge", jobBadge);
        cmd.Parameters.AddWithValue("@modalID", modalID);
        cmd.Parameters.AddWithValue("@modalDesc", modalDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int jobDelete(int jobID)
    {
        string queryStr = "DELETE FROM job WHERE jobID=@jobID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@jobID", jobID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}