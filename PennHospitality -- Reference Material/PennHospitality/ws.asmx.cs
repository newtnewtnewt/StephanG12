using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PennHospitality
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    ///To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string deleteSystemUser(string id)
        {
            if (User.IsInRole("Admin"))
            {
                return (new DSTableAdapters.QueriesTableAdapter()).spDeleteSystemUser(auid(), id).ToString();
            }
            else
            {
                return "Admin Only feature";
            }
        }

        private string auid()
        {
            return User.Identity.GetUserId();
        }

        private string get_Cookie(String cookieName)
        {
            HttpRequest Request = System.Web.HttpContext.Current.Request;

            if (Request.Cookies.Get(cookieName) != null)
            {
                return HttpUtility.UrlDecode(Request.Cookies.Get(cookieName).Value);
            }
            else
            {
                return String.Empty;
            }
        }


        //   [WebMethod]
        //    public Student HelloWorld(string fn, string ln, int id)
        //    {
        //        return new Student() { fn = fn, ln = ln, id = id };
        //    }


        //}

        //public class Student
        //{
        //    public int id { get; set; }
        //    public string fn { get; set; }
        //    public string ln{ get; set; }
        //}


    }
}

