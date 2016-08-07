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
    public partial class update_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void btnUpdateProfile_click(object sender, EventArgs e)
        {
            
            if (!FileUpload1.HasFile)
            {
                string adviID = "";
                string fileName = img_ava.ImageUrl;
                if (tbAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                updateProfile(tbProfileID.Value, tbProfileName.Value, tbProfileSurname.Value, tbProfileType.Value, tbProfileDate.Value, fileName, tbProfilePass.Value, tbProfileDegree.Value, tbProfileMail.Value, tbLink.Value, tbProfileBio.Value, tbProfileInterest.Value, adviID, tbProfileCompleteName.Value, tbProfilePhone.Value, tbProfileCode.Value);
                getSideBarInfo(txtID.InnerText);
                getUserInfo(txtID.InnerText);
            }
            else
            {
                string fileName = "userStuff/ava/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                string adviID = "";
                if (tbAdvisorName.SelectedValue == "Prof. Trung Le")
                {
                    adviID = "BEBETC01";
                }
                else
                {
                    adviID = "BEBETC02";
                }
                updateProfile(tbProfileID.Value, tbProfileName.Value, tbProfileSurname.Value, tbProfileType.Value, tbProfileDate.Value, fileName, tbProfilePass.Value, tbProfileDegree.Value, tbProfileMail.Value, tbLink.Value, tbProfileBio.Value, tbProfileInterest.Value, adviID, tbProfileCompleteName.Value, tbProfilePhone.Value, tbProfileCode.Value);
                getSideBarInfo(txtID.InnerText);
                getUserInfo(txtID.InnerText);
            }

        }

        protected void updateProfile(string id, string name, string surename, string type, string date, string ava, string pass, string degree, string mail, string link, string bio, string interest, string advisorid, string completname, string phone, string code)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [user] SET [user].ID=@string1, [user].Name=@string2, [user].Surename=@string3, [user].Type=@string4, [user].Date=@string5, [user].Ava=@string6, [user].Pass=@string7, [user].Degree=@string8, [user].Mail=@string9, [user].Link=@string10, [user].Bio=@string11, [user].Interest=@string12, [user].AdvisorID=@string13, [user].Completename=@string14, [user].Phone=@string15, [user].Code=@string16 WHERE [user].ID = @string1", ketnoi);
            cmd.Parameters.Add("string1", id);
            cmd.Parameters.Add("string2", name);
            cmd.Parameters.Add("string3", surename);
            cmd.Parameters.Add("string4", type);
            cmd.Parameters.Add("string5", date);
            cmd.Parameters.Add("string6", ava);
            cmd.Parameters.Add("string7", pass);
            cmd.Parameters.Add("string8", degree);
            cmd.Parameters.Add("string9", mail);
            cmd.Parameters.Add("string10", link);
            cmd.Parameters.Add("string11", bio);
            cmd.Parameters.Add("string12", interest);
            cmd.Parameters.Add("string13", advisorid);
            cmd.Parameters.Add("string14", completname);
            cmd.Parameters.Add("string15", phone);
            cmd.Parameters.Add("string16", code);
            cmd.ExecuteNonQuery();
            ketnoi.Close();
        }

        protected void getUserInfo(string id)
        {
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE [user].ID = @string1", ketnoi);
            cmd.Parameters.Add("string1", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbProfileID.Value = Convert.ToString(reader["ID"]);
                tbProfileName.Value = Convert.ToString(reader["Name"]);
                tbProfileSurname.Value = Convert.ToString(reader["Surename"]);
                tbProfileType.Value = Convert.ToString(reader["Type"]);
                img_ava.ImageUrl = Convert.ToString(reader["Ava"]);
                tbProfilePass.Value = Convert.ToString(reader["Pass"]);
                tbProfileDegree.Value = Convert.ToString(reader["Degree"]);
                tbProfileMail.Value = Convert.ToString(reader["Mail"]);
                tbLink.Value = Convert.ToString(reader["Link"]);
                tbProfileBio.InnerHtml = Convert.ToString(reader["Bio"]);
                tbProfileInterest.InnerHtml = Convert.ToString(reader["Interest"]);
                tbProfileCompleteName.Value = Convert.ToString(reader["Completename"]);
                tbProfilePhone.Value = Convert.ToString(reader["Phone"]);

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
                getUserInfo(id);
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