using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Diagnostics;


namespace Appgregate.NUnit_Test
{
    [TestFixture]
    public class NUnitTester
    {
        //Grey Box Testing 
        [Test]
        public void appCommentsExists()
        {
            AppComments x = new AppComments(); //Create an instance of App Comments
            Assert.That(x != null); // The page indeed exists
            

        }
        [Test]
        public void defaultExists()
        {
            _Default x = new _Default(); //Create an instance of Default Webpages
            Assert.That(x != null);      //The page does exist

        }
        [Test]
        public void moderateApps()
        {
            ModerateApps x = new ModerateApps();
            Assert.That(x != null);
        }
        //White Box Testing
        [Test]
        public void defaultPageLoad() {
            _Default x = new _Default();
            Assert.AreEqual(x.Page_Load(new object(), new EventArgs()), true);


        }
        [Test]
        public void appCommentsPageLoad()
        {   
            AppComments x = new AppComments();
            Assert.AreEqual(x.Page_Load(new object(), new EventArgs()), true);


        }
        [Test]
        public void moderateAppsPageLoad()
        {
            ModerateApps x = new ModerateApps();
            Assert.AreEqual(x.Page_Load(new object(), new EventArgs()), true);


        }





    }
}