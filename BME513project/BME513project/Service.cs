using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BME513project
{
    public class Announce
    {
        public string title { get; set; }
        public string content { get; set; }
        public string date { get; set; }
        public string ava { get; set; }
        public string authorname { get; set; }
    }
    public class Noti
    {
        public string name { get; set; }
        public string date { get; set; }
        public string action { get; set; }
        public string link { get; set; }
    }
    public class Upload
    {
        public string filename { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string link { get; set; }
        public string authorname { get; set; }
        public string project { get; set; }
        public string description { get; set; }
    }
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string authorname { get; set; }
        public string advisorname { get; set; }
        public string timelinelink { get; set; }
        public string avalink { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public string duedate { get; set; }
        public string completepercent { get; set; }
        public string stage { get; set; }
        public string boxtype { get; set; }
        public string code { get; set; }
    }

    public class ProjectDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }
        public string authorname { get; set; }
        public string authorID { get; set; }
        public string advisorname { get; set; }
        public string description { get; set; }
        public string timelinelink { get; set; }
        public string avalink { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public string duedate { get; set; }
        public string completepercent { get; set; }
        public string stage { get; set; }
        public string boxtype { get; set; }
        public string code { get; set; }
    }
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string fullname { get; set; }
        public string type { get; set; }
        public string ava { get; set; }
        public string link { get; set; }
    }

    public class Labhead
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string fullname { get; set; }
        public string type { get; set; }
        public string ava { get; set; }
        public string link { get; set; }
    }

    public class UserDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string fullname { get; set; }
        public string type { get; set; }
        public string ava { get; set; }
        public string link { get; set; }
        public string degree { get; set; }
        public string mail { get; set; }
        public string bio { get; set; }
        public string interest { get; set; }
        public string advisorid { get; set; }
        public string phone { get; set; }
    }

    public class Faci
    {
        public string id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string purpose { get; set; }
        public string link { get; set; }
        public string description { get; set; }
    }

    public class Login
    {
        public string result { get; set; }
    }
}