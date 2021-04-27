using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for cca
/// </summary>
public class cca
{
    string connectionString = ConfigurationManager.ConnectionStrings["ProjectMeDB"].ConnectionString;

    private int _ccaID;
    private string _ccaName, _ccaDesc, _ccaImage, _ccaBadge, _modalID,_modalDesc;
    
    public cca(int ccaID, string ccaName, string ccaDesc, string ccaImage,
                string ccaBadge, string modalID,  string modalDesc)
    {
        _ccaID = ccaID;
        _ccaName = ccaName;
        _ccaDesc = ccaDesc;
        _ccaImage = ccaImage;
        _ccaBadge = ccaBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }
    public cca(string ccaName, string ccaDesc,
                     string ccaImage, string ccaBadge, string modalID, string modalDesc)
    {
        _ccaName = ccaName;
        _ccaDesc = ccaDesc;
        _ccaImage = ccaImage;
        _ccaBadge = ccaBadge;
        _modalID = modalID;
        _modalDesc = modalDesc;
    }

    public cca()
    {

    }

    public int ccaID
    {
        get { return _ccaID; }
        set { _ccaID = value; }
    }

    public string ccaName
    {
        get { return _ccaName; }
        set { _ccaName = value; }
    }

    public string ccaDesc
    {
        get { return _ccaDesc; }
        set { _ccaDesc = value; }
    }

    public string ccaImage
    {
        get { return _ccaImage; }
        set { _ccaImage = value; }
    }

    public string ccaBadge
    {
        get { return _ccaBadge; }
        set { _ccaBadge = value; }
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

    public int ccaInsert()
    {
        int result = 0;

        string queryStr = "INSERT INTO cca(ccaName,ccaDesc,ccaImage,ccaBadge,"
                        + "modalID,modalDesc)values(@ccaName,@ccaDesc,@ccaImage,"
                        + "@ccaBadge,@modalID,@modalDesc)";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ccaName", this._ccaName);
        cmd.Parameters.AddWithValue("@ccaDesc", this._ccaDesc);
        cmd.Parameters.AddWithValue("@ccaImage", this._ccaImage);
        cmd.Parameters.AddWithValue("@ccaBadge", this._ccaBadge);
        cmd.Parameters.AddWithValue("@modalID", this._modalID);
        cmd.Parameters.AddWithValue("@modalDesc", this._modalDesc);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }

    public cca getcca(int ccaID)
    {
        cca ccaDetail = null;
        string ccaName, ccaDesc, ccaImage, ccaBadge;
        string modalID, modalDesc;
        string queryStr = "SELECT * FROM cca WHERE ccaID = @ccaID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ccaID", ccaID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            ccaName = dr["ccaName"].ToString();
            ccaDesc = dr["ccaDesc"].ToString();
            ccaImage = dr["ccaImage"].ToString();
            ccaBadge = dr["ccaBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            ccaDetail = new cca(ccaID, ccaName, ccaDesc, ccaImage, ccaBadge, modalID, modalDesc);
        }

        else
        {
            ccaDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return ccaDetail;
    }

    public List<cca> getccaAll()
    {
        List<cca> ccaList = new List<cca>();
        cca ccaDetail = null;
        string ccaName, ccaDesc, ccaImage, ccaBadge;
        string modalID, modalDesc;
        int ccaID;
        string queryStr = "SELECT * FROM cca ORDER BY ccaID DESC";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            ccaID = int.Parse(dr["ccaID"].ToString());
            ccaName = dr["ccaName"].ToString();
            ccaDesc = dr["ccaDesc"].ToString();
            ccaImage = dr["ccaImage"].ToString();
            ccaBadge = dr["ccaBadge"].ToString();
            modalID = dr["modalID"].ToString();
            modalDesc = dr["modalDesc"].ToString();
            ccaDetail = new cca(ccaID, ccaName, ccaDesc, ccaImage, ccaBadge, modalID, modalDesc);
            ccaList.Add(ccaDetail);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return ccaList;

    }

    public int ccaUpdate(int ccaID, string ccaName, string ccaDesc,
                               string ccaImage, string ccaBadge, string modalID, string modalDesc)
    {
        string queryStr = "UPDATE cca SET" +
        " ccaName = @ccaName, " +
        " ccaDesc = @ccaDesc, " +
        " ccaImage = @ccaImage, " +
        " ccaBadge = @ccaBadge, " +
        " modalID = @modalID," +
        " modalDesc = @modalDesc" +
        " WHERE ccaID = @ccaID";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ccaID", ccaID);
        cmd.Parameters.AddWithValue("@ccaName", ccaName);
        cmd.Parameters.AddWithValue("@ccaDesc", ccaDesc);
        cmd.Parameters.AddWithValue("@ccaImage", ccaImage);
        cmd.Parameters.AddWithValue("@ccaBadge", ccaBadge);
        cmd.Parameters.AddWithValue("@modalID", modalID);
        cmd.Parameters.AddWithValue("@modalDesc", modalDesc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int ccaDelete(int ccaID)
    {
        string queryStr = "DELETE FROM cca WHERE ccaID=@ccaID";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ccaID", ccaID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

}