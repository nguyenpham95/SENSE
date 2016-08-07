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
    public partial class project : System.Web.UI.Page
    {
        string currentProj = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void btnUpdateProject_click(object sender, EventArgs e)
        {

            if (!FileUpload1.HasFile)
            {
                string adviID = "";
                string fileName = img_ava.ImageUrl;
                if (tbProjectAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                updateProject(tbProjID.Value, tbProjName.Value, txtID.InnerHtml, adviID, tbProjDes.Value, fileName, tbProjStatus.Value, tbProjDate.Value, tbProjDueDate.Value, tbProjPercent.Value, tbProjStage.Value, tbProjCode.Value, tbProjShortname.Value, txtID.InnerHtml, currentProj);
                getSideBarInfo(txtID.InnerText);
                getUserProject(txtID.InnerText);
            }
            else
            {
                string fileName = "userStuff/ava/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                string adviID = "";
                if (tbProjectAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                updateProject(tbProjID.Value, tbProjName.Value, txtID.InnerHtml, adviID, tbProjDes.Value, fileName, tbProjStatus.Value, tbProjDate.Value, tbProjDueDate.Value, tbProjPercent.Value, tbProjStage.Value, tbProjCode.Value, tbProjShortname.Value, txtID.InnerHtml, currentProj);
                getSideBarInfo(txtID.InnerText);
                getUserProject(txtID.InnerText);
            }

        }

        protected void btnCreateProject_click(object sender, EventArgs e)
        {

            if (!FileUpload1.HasFile)
            {
                string adviID = "";
                string fileName = img_ava.ImageUrl;
                if (tbProjectAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                createProject(tbProjID.Value, tbProjName.Value, txtID.InnerHtml, adviID, tbProjDes.Value, fileName, tbProjStatus.Value, tbProjDate.Value, tbProjDueDate.Value, tbProjPercent.Value, tbProjStage.Value, tbProjCode.Value, tbProjShortname.Value);
                getSideBarInfo(txtID.InnerText);
                getUserProject(txtID.InnerText);
            }
            else
            {
                string fileName = "userStuff/ava/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                string adviID = "";
                if (tbProjectAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                createProject(tbProjID.Value, tbProjName.Value, txtID.InnerHtml, adviID, tbProjDes.Value, fileName, tbProjStatus.Value, tbProjDate.Value, tbProjDueDate.Value, tbProjPercent.Value, tbProjStage.Value, tbProjCode.Value, tbProjShortname.Value);
                getSideBarInfo(txtID.InnerText);
                getUserProject(txtID.InnerText);
            }

        }
        protected void createProject(string id, string name, string authorid, string advisorid, string description, string avalink, string status, string date, string duedate, string complete, string stage, string code, string shortname)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO project VALUES(@string1,@string2,@string3,@string4,@string5,'none',@string6,@string7,@string8,@string9,@string10,@string11,'none',@string12,@string13)", ketnoi);
            cmd.Parameters.Add("string1", id);
            cmd.Parameters.Add("string2", name);
            cmd.Parameters.Add("string3", authorid);
            cmd.Parameters.Add("string4", advisorid);
            cmd.Parameters.Add("string5", description);
            cmd.Parameters.Add("string6", avalink);
            cmd.Parameters.Add("string7", status);
            cmd.Parameters.Add("string8", date);
            cmd.Parameters.Add("string9", duedate);
            cmd.Parameters.Add("string10", complete);
            cmd.Parameters.Add("string11", stage);
            cmd.Parameters.Add("string12", code);
            cmd.Parameters.Add("string13", shortname);
            cmd.ExecuteNonQuery();
            ketnoi.Close();
        }

        protected void updateProject(string id, string name, string authorid, string advisorid, string description, string avalink, string status, string date, string duedate, string complete, string stage, string code, string shortname, string doichieuID, string doichieuProjectID)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("UPDATE project SET project.ID=@string1, project.ProjectName=@string2, project.AuthorID=@string3, project.AdvisorID=@string4, project.Description=@string5, project.AvaLink=@string6, project.Status=@string7, project.Date=@string8, project.Duedate=@string9, project.CompletePercent=@string10, project.Stage=@string11, project.Code=@string12, project.Shortname=@string13 WHERE project.AuthorID = @string14 AND project.ID=@string15", ketnoi);
            cmd.Parameters.Add("string1", id);
            cmd.Parameters.Add("string2", name);
            cmd.Parameters.Add("string3", authorid);
            cmd.Parameters.Add("string4", advisorid);
            cmd.Parameters.Add("string5", description);
            cmd.Parameters.Add("string6", avalink);
            cmd.Parameters.Add("string7", status);
            cmd.Parameters.Add("string8", date);
            cmd.Parameters.Add("string9", duedate);
            cmd.Parameters.Add("string10", complete);
            cmd.Parameters.Add("string11", stage);
            cmd.Parameters.Add("string12", code);
            cmd.Parameters.Add("string13", shortname);
            cmd.Parameters.Add("string14", doichieuID);
            cmd.Parameters.Add("string15", doichieuProjectID);
            cmd.ExecuteNonQuery();
            ketnoi.Close();
        }

        protected void getUserProject(string id)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE project.AuthorID = @string1", ketnoi);
            cmd.Parameters.Add("string1", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbProjID.Value = Convert.ToString(reader["ID"]);
                currentProj = tbProjID.Value;
                txtName.InnerText = currentProj;
                tbProjName.Value = Convert.ToString(reader["ProjectName"]);
                tbProjAuthorID.Value = txtID.InnerHtml;
                tbProjDes.Value = Convert.ToString(reader["Description"]);
                img_ava.ImageUrl = Convert.ToString(reader["AvaLink"]);
                tbProjStatus.Value = Convert.ToString(reader["Status"]);
                tbProjDueDate.Value = Convert.ToString(reader["Duedate"]);
                tbProjDate.Value = Convert.ToString(reader["Date"]);
                tbProjPercent.Value = Convert.ToString(reader["CompletePercent"]);
                tbProjStage.Value = Convert.ToString(reader["Stage"]);
                tbProjCode.Value = Convert.ToString(reader["Code"]);
                tbProjShortname.Value = Convert.ToString(reader["Shortname"]);
            }
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