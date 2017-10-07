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

            private BookStoreEntities2 _db = new BookStoreEntities2();

            public ActionResult Index(string txtName, string txtAuthor,string txtPages,string txtYear,string submit)
            {
               return View(_db.Books.ToList());
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

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
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
        public JsonResult InsertInDatabase(string name, string author, string type_of_book,string pages, string year)
        {
            Book person = new Book
            {
                NameBook = name,
                Author=author,
                Pages=pages,
                Year=year,
                Type_of_book = type_of_book,
                DateTime = DateTime.Now.ToString()
            };
            string query = "INSERT INTO Books (Name,Author,Pages,Year_of_publishing,type_of_book) VALUES ('" + name + "','" + author + "','" + pages + "','" + year + "','" + type_of_book + "')";

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\BookStore.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"))
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
