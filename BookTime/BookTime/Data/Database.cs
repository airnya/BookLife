using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookTime.Models;
using Xamarin.Forms;

namespace BookTime.Data
{
    public class Database
    {
        private SQLiteConnection _sqlconnection;
        public Database()
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Book>();
            //_sqlconnection.CreateTable<User>();
            _sqlconnection.CreateTable<Category>();

        }

        public IEnumerable<Book> GetBooks()
        {
            return _sqlconnection.Table<Book>();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _sqlconnection.Table<Category>();
        }

        //Get specific book  
        public Book GetBook(int id)
        {
            return _sqlconnection.Table<Book>().FirstOrDefault(t => t.Id == id);
        }

        public Category GetCategory(int id)
        {
            return _sqlconnection.Table<Category>().FirstOrDefault(t => t.Id == id);
        }

        public Book GetBookByBarcode(string barcode)
        {
            return _sqlconnection.Table<Book>().Where(b => b.ISBNnumber.Equals(barcode)).FirstOrDefault();
        }

        //Delete specific book  
        public void DeleteBook(int id)
        {
            _sqlconnection.Delete<Book>(id);
        }

        public void DeleteCategory(int id)
        {
            _sqlconnection.Delete<Category>(id);
        }

        //Add new book to DB  
        public void AddBook(Book book)
        {
            if (book.Id != 0)
            {
                _sqlconnection.Update(book);
            }
            else
            {
                _sqlconnection.Insert(book);
            }
        }

        public void AddCategory(Category name)
        {
            _sqlconnection.Insert(name);
        }

        public void SaveBook(Book book)
        {   
           _sqlconnection.Insert(book);
        }

        public IEnumerable<Book> SearchBookByTitle(string bookName)
        {
            return _sqlconnection.Table<Book>().Where(b => b.BookTitle.ToUpper().Contains(bookName.ToUpper()));
        }

        public IEnumerable<Book> SearchBookByAuthor(string authorName)
        {
            return _sqlconnection.Table<Book>().Where(b => b.BookAuthor.ToUpper().Contains(authorName.ToUpper()));
        }

        public IEnumerable<Book> SearchBookByCategory(string category)
        {
            return _sqlconnection.Table<Book>().Where(b => b.BookCategory.ToUpper().Contains(category.ToUpper()));
        }

        public IEnumerable<Book> SearchBookByIsbn(string bookIsbn)
        {
            return _sqlconnection.Query<Book>($"SELECT * FROM Book WHERE ISBNnumber like '%{bookIsbn}%'").ToList();

            //return _sqlconnection.Table<Book>().Where(b => b.ISBNnumber.Contains(bookIsbn));
        }

    }
}
