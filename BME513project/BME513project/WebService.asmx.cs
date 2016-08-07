using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Globalization;
namespace BME513project
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
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
        [WebMethod]
        public void getAnnouncement()
        {
            List<Announce> ListAnnounce = new List<Announce>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT announcement.Title, announcement.Content, announcement.Date, [user].Name, [user].Surename, [user].Ava FROM announcement, [user] WHERE announcement.authorID = [user].ID ORDER BY announcement.Date DESC", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Announce a = new Announce();
                a.title = Convert.ToString(reader["Title"]);
                a.content = Convert.ToString(reader["Content"]);
                a.ava = Convert.ToString(reader["Ava"]);
                CultureInfo provider = CultureInfo.InvariantCulture;
                string date = Convert.ToString(reader["Date"]);
                DateTime oDate = DateTime.Parse(date);
                a.date = oDate.Day + "th, "+ oDate.Month + "/" + oDate.Year;
                string fullname = Convert.ToString(reader["Name"]) + " " + Convert.ToString(reader["Surename"]);
                a.authorname = fullname;
                ListAnnounce.Add(a);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListAnnounce));
        }

        [WebMethod]
        public void getNoti()
        {
            List<Noti> listNoti = new List<Noti>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT noti.action, noti.date, noti.link, [user].Name, [user].Surename FROM noti, [user] WHERE noti.userID = [user].ID ORDER BY noti.date DESC", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Noti n = new Noti();
                n.name = reader["Name"] + " " + reader["Surename"];
                n.action = Convert.ToString(reader["action"]);
                string datestr = Convert.ToString(reader["date"]);
                DateTime oDate = DateTime.Parse(datestr);
                n.date = oDate.Day + "th, " + oDate.Month + " - " + oDate.Year;
                n.link = Convert.ToString(reader["link"]);
                listNoti.Add(n);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listNoti));
        }

        [WebMethod]
        public void getUpload()
        {
            List<Upload> ListUpload = new List<Upload>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT upload.filename, upload.date, upload.link, upload.status, upload.project, upload.Description, [user].Name, [user].Surename FROM upload, [user] WHERE upload.authorID = [user].ID ORDER BY upload.date DESC", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Upload u = new Upload();
                u.filename = Convert.ToString(reader["filename"]);
                string datestr = Convert.ToString(reader["date"]);
                DateTime oDate = DateTime.Parse(datestr);
                u.date = oDate.Day + " - " + oDate.Month + " - " + oDate.Year;
                u.link = Convert.ToString(reader["link"]);
                u.status = Convert.ToString(reader["status"]);
                u.project = Convert.ToString(reader["project"]);
                u.description = Convert.ToString(reader["Description"]);
                u.authorname = reader["Name"] + " " + reader["Surename"];
                ListUpload.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUpload));
        }

        [WebMethod]
        public void getUploadByID(string proID)
        {
            List<Upload> ListUpload = new List<Upload>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT upload.filename, upload.date, upload.link, upload.status, upload.project, upload.Description, [user].Name, [user].Surename FROM upload, [user] WHERE upload.authorID = [user].ID AND upload.project = @string ORDER BY upload.date DESC", ketnoi);
            cmd.Parameters.Add("string", proID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Upload u = new Upload();
                u.filename = Convert.ToString(reader["filename"]);
                string datestr = Convert.ToString(reader["date"]);
                DateTime oDate = DateTime.Parse(datestr);
                u.date = oDate.Day + " - " + oDate.Month + " - " + oDate.Year;
                u.link = Convert.ToString(reader["link"]);
                u.status = Convert.ToString(reader["status"]);
                u.project = Convert.ToString(reader["project"]);
                u.description = Convert.ToString(reader["Description"]);
                u.authorname = reader["Name"] + " " + reader["Surename"];
                ListUpload.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUpload));
        }
        [WebMethod]
        public void getUploadByAuthorID(string authorID)
        {
            List<Upload> ListUpload = new List<Upload>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT upload.filename, upload.date, upload.link, upload.status, upload.project, upload.Description, [user].Name, [user].Surename FROM upload, [user] WHERE upload.authorID = [user].ID AND upload.authorID = @string ORDER BY upload.date DESC", ketnoi);
            cmd.Parameters.Add("string", authorID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Upload u = new Upload();
                u.filename = Convert.ToString(reader["filename"]);
                string datestr = Convert.ToString(reader["date"]);
                DateTime oDate = DateTime.Parse(datestr);
                u.date = oDate.Day + " - " + oDate.Month + " - " + oDate.Year;
                u.link = Convert.ToString(reader["link"]);
                u.status = Convert.ToString(reader["status"]);
                u.project = Convert.ToString(reader["project"]);
                u.description = Convert.ToString(reader["Description"]);
                u.authorname = reader["Name"] + " " + reader["Surename"];
                ListUpload.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUpload));
        }
        [WebMethod]
        public void getUploadByAuthorLink(string authorLink)
        {
            List<Upload> ListUpload = new List<Upload>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT upload.filename, upload.date, upload.link, upload.status, upload.project, upload.Description, [user].Name, [user].Surename FROM upload, [user] WHERE upload.authorID = [user].ID AND [user].Link = @string ORDER BY upload.date DESC", ketnoi);
            cmd.Parameters.Add("string", authorLink);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Upload u = new Upload();
                u.filename = Convert.ToString(reader["filename"]);
                string datestr = Convert.ToString(reader["date"]);
                DateTime oDate = DateTime.Parse(datestr);
                u.date = oDate.Day + " - " + oDate.Month + " - " + oDate.Year;
                u.link = Convert.ToString(reader["link"]);
                u.status = Convert.ToString(reader["status"]);
                u.project = Convert.ToString(reader["project"]);
                u.description = Convert.ToString(reader["Description"]);
                u.authorname = reader["Name"] + " " + reader["Surename"];
                ListUpload.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUpload));
        }
        [WebMethod]
        public void getProject()
        {
            List<Project> ListProject = new List<Project>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT project.ID, project.ProjectName, project.Description, project.TimelineLink, project.AvaLink, project.Status, project. Date, project.Duedate, project.CompletePercent, project.Stage, project.Boxtype, project.Code, [user].Name, [user].Surename FROM project, [user] WHERE project.AuthorID = [user].ID ORDER BY project.Date DESC", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Project p = new Project();
                p.id = Convert.ToString(reader["ID"]);
                p.name = Convert.ToString(reader["ProjectName"]);
                p.authorname = reader["Name"] + " " + reader["Surename"];
                p.advisorname = "Trung Le";
                p.timelinelink = Convert.ToString(reader["TimelineLink"]);
                p.avalink = Convert.ToString(reader["AvaLink"]);
                p.status = Convert.ToString(reader["Status"]);
                string date = Convert.ToString(reader["Date"]);
                DateTime oDate = DateTime.Parse(date);
                p.date = oDate.Month + " / " + oDate.Year;
                string date2 = Convert.ToString(reader["Duedate"]);
                DateTime oDate2 = DateTime.Parse(date2);
                p.duedate = oDate2.Month + " / " + oDate2.Year;
                p.completepercent = Convert.ToString(reader["CompletePercent"]);
                p.stage = Convert.ToString(reader["Stage"]);
                p.boxtype = Convert.ToString(reader["Boxtype"]);
                p.code = Convert.ToString(reader["Code"]);
                ListProject.Add(p);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListProject));
        }

        [WebMethod]
        public void getProjectByAuthorLink(string authorLink)
        {
            List<Project> ListProject = new List<Project>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT project.ID, project.ProjectName, project.Description, project.TimelineLink, project.AvaLink, project.Status, project. Date, project.Duedate, project.CompletePercent, project.Stage, project.Boxtype, project.Code, [user].Name, [user].Surename FROM project, [user] WHERE [user].Link = @string AND project.AuthorID = [user].ID ORDER BY project.Date DESC", ketnoi);
            cmd.Parameters.Add("string", authorLink);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Project p = new Project();
                p.id = Convert.ToString(reader["ID"]);
                p.name = Convert.ToString(reader["ProjectName"]);
                p.authorname = reader["Name"] + " " + reader["Surename"];
                p.advisorname = "Trung Le";
                p.timelinelink = Convert.ToString(reader["TimelineLink"]);
                p.avalink = Convert.ToString(reader["AvaLink"]);
                p.status = Convert.ToString(reader["Status"]);
                string date = Convert.ToString(reader["Date"]);
                DateTime oDate = DateTime.Parse(date);
                p.date = oDate.Month + " / " + oDate.Year;
                string date2 = Convert.ToString(reader["Duedate"]);
                DateTime oDate2 = DateTime.Parse(date2);
                p.duedate = oDate2.Month + " / " + oDate2.Year;
                p.completepercent = Convert.ToString(reader["CompletePercent"]);
                p.stage = Convert.ToString(reader["Stage"]);
                p.boxtype = Convert.ToString(reader["Boxtype"]);
                p.code = Convert.ToString(reader["Code"]);
                ListProject.Add(p);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListProject));
        }

        [WebMethod]
        public void getProjectDetail(string proID)
        {
            List<ProjectDetail> ListProject = new List<ProjectDetail>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT project.ID, project.Shortname, project.ProjectName, project.Description, project.TimelineLink, project.AvaLink, project.Status, project. Date, project.Duedate, project.CompletePercent, project.Stage, project.Boxtype, project.Code, [user].Name, [user].Surename, [user].ID AS authorID FROM project, [user] WHERE project.AuthorID = [user].ID AND project.ID = @projectID ORDER BY project.Date DESC", ketnoi);
            cmd.Parameters.Add("projectID", proID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProjectDetail p = new ProjectDetail();
                p.id = Convert.ToString(reader["ID"]);
                p.name = Convert.ToString(reader["ProjectName"]);
                p.shortname = Convert.ToString(reader["Shortname"]);
                p.description = Convert.ToString(reader["Description"]);
                p.authorname = reader["Name"] + " " + reader["Surename"];
                p.advisorname = "Trung Le";
                p.authorID = Convert.ToString(reader["authorID"]);
                p.timelinelink = Convert.ToString(reader["TimelineLink"]);
                p.avalink = Convert.ToString(reader["AvaLink"]);
                p.status = Convert.ToString(reader["Status"]);
                string date = Convert.ToString(reader["Date"]);
                DateTime oDate = DateTime.Parse(date);
                p.date = oDate.Month + " / " + oDate.Year;
                string date2 = Convert.ToString(reader["Duedate"]);
                DateTime oDate2 = DateTime.Parse(date2);
                p.duedate = oDate2.Month + " / " + oDate2.Year;
                p.completepercent = Convert.ToString(reader["CompletePercent"]);
                p.stage = Convert.ToString(reader["Stage"]);
                p.boxtype = Convert.ToString(reader["Boxtype"]);
                p.code = Convert.ToString(reader["Code"]);
                ListProject.Add(p);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListProject));
        }

        [WebMethod]
        public void getAllUser()
        {
            List<User> ListUser = new List<User>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT [user].Name, [user].Completename, [user].Surename, [user].ID, [user].Type, [user].Ava, [user].Link FROM [user] WHERE [user].AdvisorID LIKE 'BEBE%' ORDER BY [user].Date DESC", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u = new User();
                u.id = Convert.ToString(reader["ID"]);
                u.surename = Convert.ToString(reader["Surename"]);
                u.name = Convert.ToString(reader["Name"]);
                u.fullname = Convert.ToString(reader["Completename"]);
                u.ava = Convert.ToString(reader["Ava"]);
                u.type = Convert.ToString(reader["Type"]);
                u.link = Convert.ToString(reader["Link"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }

        [WebMethod]
        public void getAllLabhead()
        {
            List<User> ListUser = new List<User>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT [user].Name, [user].Completename, [user].Surename, [user].ID, [user].Type, [user].Ava, [user].Link FROM [user] WHERE [user].AdvisorID LIKE 'none%'", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u = new User();
                u.id = Convert.ToString(reader["ID"]);
                u.surename = Convert.ToString(reader["Surename"]);
                u.name = Convert.ToString(reader["Name"]);
                u.fullname = Convert.ToString(reader["Completename"]);
                u.ava = Convert.ToString(reader["Ava"]);
                u.type = Convert.ToString(reader["Type"]);
                u.link = Convert.ToString(reader["Link"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }

        [WebMethod]
        public void getUserByID(string userID)
        {
            List<User> ListUser = new List<User>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT [user].Name, [user].Surename, [user].ID, [user].Type, [user].Ava, [user].Link FROM [user] WHERE [user].ID = @string", ketnoi);
            cmd.Parameters.Add("string", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u = new User();
                u.id = Convert.ToString(reader["ID"]);
                u.surename = Convert.ToString(reader["Surename"]);
                u.name = Convert.ToString(reader["Name"]);
                u.fullname = u.name + " " + u.surename;
                u.ava = Convert.ToString(reader["Ava"]);
                u.type = Convert.ToString(reader["Type"]);
                u.link = Convert.ToString(reader["Link"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }

        [WebMethod]
        public void getAdvisorByID(string userID)
        {
            List<Labhead> ListUser = new List<Labhead>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT [user].Name, [user].Link, [user].Surename, [user].ID, [user].Type, [user].Ava FROM [user] WHERE [user].ID = @string AND [user].AdvisorID LIKE 'none%'", ketnoi);
            cmd.Parameters.Add("string", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Labhead u = new Labhead();
                u.id = Convert.ToString(reader["ID"]);
                u.surename = Convert.ToString(reader["Surename"]);
                u.name = Convert.ToString(reader["Name"]);
                u.fullname = u.name + " " + u.surename;
                u.ava = Convert.ToString(reader["Ava"]);
                u.type = Convert.ToString(reader["Type"]);
                u.link = Convert.ToString(reader["Link"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }

        [WebMethod]
        public void getUserByLink(string userLink)
        {
            List<UserDetail> ListUser = new List<UserDetail>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT [user].Name, [user].Surename, [user].ID, [user].Type, [user].Ava, [user].Degree, [user].Mail, [user].Link, [user].Bio, [user].Interest, [user].AdvisorID, [user].Completename, [user].phone FROM [user] WHERE [user].Link = @string", ketnoi);
            cmd.Parameters.Add("string", userLink);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserDetail u = new UserDetail();
                u.id = Convert.ToString(reader["ID"]);
                u.surename = Convert.ToString(reader["Surename"]);
                u.name = Convert.ToString(reader["Name"]);
                u.fullname = Convert.ToString(reader["Completename"]);
                u.ava = Convert.ToString(reader["Ava"]);
                u.type = Convert.ToString(reader["Type"]);
                u.degree = Convert.ToString(reader["Degree"]);
                u.mail = Convert.ToString(reader["Mail"]);
                u.link = Convert.ToString(reader["Link"]);
                u.bio = Convert.ToString(reader["Bio"]);
                u.interest = Convert.ToString(reader["Interest"]);
                u.advisorid = Convert.ToString(reader["AdvisorID"]);
                u.phone = Convert.ToString(reader["Phone"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }



        [WebMethod]
        public void getProjectByAuthorID(string authorID)
        {
            List<Project> ListProject = new List<Project>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT project.ID, project.ProjectName, project.Description, project.TimelineLink, project.AvaLink, project.Status, project. Date, project.Duedate, project.CompletePercent, project.Stage, project.Boxtype, project.Code, [user].Name, [user].Surename FROM project, [user] WHERE project.AuthorID = @string AND project.AuthorID = [user].ID ORDER BY project.Date DESC", ketnoi);
            cmd.Parameters.Add("string", authorID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Project p = new Project();
                p.id = Convert.ToString(reader["ID"]);
                p.name = Convert.ToString(reader["ProjectName"]);
                p.authorname = reader["Name"] + " " + reader["Surename"];
                p.advisorname = "Trung Le";
                p.timelinelink = Convert.ToString(reader["TimelineLink"]);
                p.avalink = Convert.ToString(reader["AvaLink"]);
                p.status = Convert.ToString(reader["Status"]);
                string date = Convert.ToString(reader["Date"]);
                DateTime oDate = DateTime.Parse(date);
                p.date = oDate.Month + " / " + oDate.Year;
                string date2 = Convert.ToString(reader["Duedate"]);
                DateTime oDate2 = DateTime.Parse(date2);
                p.duedate = oDate2.Month + " / " + oDate2.Year;
                p.completepercent = Convert.ToString(reader["CompletePercent"]);
                p.stage = Convert.ToString(reader["Stage"]);
                p.boxtype = Convert.ToString(reader["Boxtype"]);
                p.code = Convert.ToString(reader["Code"]);
                ListProject.Add(p);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListProject));
        }

        [WebMethod]
        public void getAllFaci()
        {
            List<Faci> ListUser = new List<Faci>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM faci", ketnoi);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Faci u = new Faci();
                u.id = Convert.ToString(reader["ID"]);
                u.name = Convert.ToString(reader["Name"]);
                u.link = Convert.ToString(reader["Link"]);
                u.description = Convert.ToString(reader["Description"]);
                u.model = Convert.ToString(reader["Model"]);
                u.purpose = Convert.ToString(reader["Purpose"]);
                ListUser.Add(u);
            }
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }
        [WebMethod]
        public void checkLogin(string id, string pass)
        {
            List<Login> ListUser = new List<Login>();
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            SqlConnection ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE [user].ID = @string1 AND [user].Pass = @string2", ketnoi);
            cmd.Parameters.Add("string1", id);
            cmd.Parameters.Add("string2", pass);
            SqlDataReader reader = cmd.ExecuteReader();
            Login lg = new Login();
            if (reader.HasRows)
            {
                lg.result = "success";               
            }
            else
            {
                lg.result = "Login Failed - Please try again";
            }
            ListUser.Add(lg);
            ketnoi.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ListUser));
        }
    }
}
