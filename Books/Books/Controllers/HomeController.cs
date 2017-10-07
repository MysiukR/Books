using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.SqlClient;
using System.Web.Services;

namespace Books.Controllers
{
    public class HomeController : Controller
    {

            private BookStoreEntities1 _db = new BookStoreEntities1();

            public ActionResult Index(string txtName, string txtAuthor,string txtPages,string txtYear,string submit)
            {
            /*
                        string s1 = txtName;//
                        string s2 = txtAuthor;//
                        string s3 = txtPages;

                        if (submit == "Login")
                        {

                            string query = "INSERT INTO Books (Name,Author,Price) VALUES ('" + s1 + "','" + s2 + "','" + s3 + "')";

                            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musyk\\Desktop\\Books\\Books\\App_Data\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
                            {
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                }
                            }

                        }else if(submit == "Remove")
                        { 
                                string query = "SELECT * FROM Book";

                                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musyk\\Desktop\\Books\\Books\\App_Data\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
                                {
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        connection.Open();
                                        command.ExecuteNonQuery();
                                    }
                                }

                        }*/

            //query = "DELETE FROM Books WHERE id = 60";
            return View(_db.Books.ToList());//MovieSet.ToList());

            }
        [WebMethod]
        [HttpPost]
        public JsonResult AjaxMethod(string name,string author,string pages)
        {
            Book person = new Book
            {
                Name = name,
                DateTime = DateTime.Now.ToString()
            };
            string query = "DELETE FROM Books WHERE Name='"+name+"' AND Author='"+author+"' AND Pages='"+pages+"'";

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musyk\\Desktop\\Books\\Books\\App_Data\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Json(person);
        }
        [WebMethod]
        [HttpPost]
        public JsonResult InsertInDatabase(string name, string author, string pages, string year)
        {
            Book person = new Book
            {
                NameBook = name,
                Author=author,
                Pages=pages,
                Year=year,
                DateTime = DateTime.Now.ToString()
            };
            string query = "INSERT INTO Books (Name,Author,Pages,Year_of_publishing) VALUES ('" + name + "','" + author + "','" + pages + "','" + year + "')";

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musyk\\Desktop\\Books\\Books\\App_Data\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return Json(person);
        }
    }

    }
