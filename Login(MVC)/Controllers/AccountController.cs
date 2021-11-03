using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie3.Models;
using System.Data.SqlClient;
namespace MvcMovie3.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]


        public ActionResult Login()
        {


            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-DGH5HGO;database =Club_sport; integrated security =SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();

            com.Connection = con;
            com.CommandText = "select *from Login where username ='" + acc.Name + "' and password = '" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Verify");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}

          
        

    