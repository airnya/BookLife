using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTime.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BookImagePath { get; set; }
        public string BookTitle { get; set; }
       [Unique]
        public string ISBNnumber { get; set; }
        public string BookAuthor { get; set; }
        public string BookCategory { get; set; }
        public string BookDescription { get; set; }
        public int owner_id { get; set; }

        public override string ToString()
        {
            return string.Format("[Book: Id={0}, BookTitle={1}, ISBNnumber={2}, BookImagePath={3}]", Id, BookTitle, ISBNnumber, BookImagePath);
       }
    }

    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CategoryImagePath { get; set; }
        public string CategoryName { get; set; }
    }

}