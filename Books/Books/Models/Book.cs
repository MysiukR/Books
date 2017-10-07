using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Book
    {
           
           public string BookId { get; set; }
           public string Year { get; set; }
           public string NameBook { get; set; }
           public string Pages { get; set; }
           public string Author { get; set; }
           public string Name { get; set; }
           public string Type_of_book { get; set; }
           public string DateTime { get; set; }
    }
}