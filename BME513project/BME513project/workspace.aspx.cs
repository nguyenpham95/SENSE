using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BME513project
{
    public partial class workspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && FileUpload1.HasFile)
            {
                string fileName = "userStuff/upload/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                createUpload(tbFileName.Value, tbDate.Value, lbStatus.Text, fileName, txtID.InnerText, tbProjectID.Value, tbDes.Value);
            }
            
        }
        
        

        
        protected void createUpload(string filename, string date, string status, string link, string authorID, string project, string description)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO upload VALUES(@string1, @string2, @string3, @string4, @string5, @string6, @string7)", ketnoi);
            cmd.Parameters.Add("string1", filename);
            cmd.Parameters.Add("string2", date);
            cmd.Parameters.Add("string3", status);
            cmd.Parameters.Add("string4", link);
            cmd.Parameters.Add("string5", authorID);
            cmd.Parameters.Add("string6", project);
            cmd.Parameters.Add("string7", description);
            cmd.ExecuteNonQuery();
            ketnoi.Close();
        }
        protected void perform_Login(object sender, EventArgs e)
        {
            string id = tb_ID.Value;
            string pass = tb_Pass.Value;
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE [user].ID = @string1 AND [user].Pass = @string2", ketnoi);
            cmd.Parameters.Add("string1", id);
            cmd.Parameters.Add("string2", pass);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                main_page.Visible = true;
                login_page.Visible = false;
                nenden.Visible = false;
                getSideBarInfo(id);
            }
            else
            {
                main_page.Visible = false;
                login_page.Visible = true;
                nenden.Visible = true;
            }
            ketnoi.Close();
        }
        protected void getSideBarInfo(string id)
        {            
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE [user].ID = @string1", ketnoi);
            cmd.Parameters.Add("string1", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                imgAVA.Src = Convert.ToString(reader["Ava"]);
                txtID.InnerText = Convert.ToString(reader["ID"]);
                txtName.InnerText = Convert.ToString(reader["Completename"]);
            }
            ketnoi.Close();
        }
    }
}