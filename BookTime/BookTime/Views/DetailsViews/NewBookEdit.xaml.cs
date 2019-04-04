using BookTime.Models;
using BookTime.Parsers;
using htmlParsing.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookTime.Views.DetailsViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookEdit : ContentPage
    {
        App app = (App)Application.Current;
        ObservableCollection<Category> CategoryList;


        ParserWorker<string[]> parser;
        ParserWorker<string[]> parserIsbn;


        public Book book { get; set; }

        public string ISBN
        {
            set
            {
                book_isbn.Text = value;
            }
            get { return book_isbn.Text; }
        }
        public string BookId
        {
            set
            {
                OzonBookId.Text = value;
            }
            get { return OzonBookId.Text; }
        }
        public NewBookEdit()
        {
            Title = "ДОБАВЛЕНИЕ КНИГИ";
            InitializeComponent();

            book = new Book
            {
                BookTitle = "",
                BookAuthor = "",
                BookCategory = "",
                BookDescription = "",
                ISBNnumber = "",
                BookImagePath = "icon.png"
            };
            BindingContext = this;

            CategoryList = new ObservableCollection<Category>(app.Database.GetCategories().ToList());
            book_category.ItemsSource = CategoryList;

            parser = new ParserWorker<string[]>(new OzonParser());
            parserIsbn = new ParserWorker<string[]>(new AmazonParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
            parserIsbn.OnCompleted += Parser_OnCompleted;
            parserIsbn.OnNewData += Parser_OnNewData;
            //            book_isbn.Text = "9785941575381";

            if (OzonBookId.Text != null) 
            {

                ButtonStart_Click(this, EventArgs.Empty);
                parser.Settings = new OzonSettings(OzonBookId.Text);
                parser.Start();
            }

        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            //  listView.ItemsSource.Add(arg2);
            try
            {
                string prefix = "https:";
                var BookTitle = (arg2[0]);
                var BookAuthor = (arg2[1]);
                var BookImg = (arg2[2]).Replace("https:", "");
                var BookIsbn = (arg2[3]);

                book_author.Text = BookAuthor.Replace(",\n", "");
                book_title.Text = BookTitle;
                book_isbn.Text = book_isbn.Text + BookIsbn.Replace("\n", "");
                bookCover.Source = prefix + BookImg;
                book_cover.Text = prefix + BookImg;
            }
            catch (IndexOutOfRangeException s)
            {
                DisplayAlert("Ошибка", "нет книги с таким ID/ISBN", "OK");
            }
        }

        private void Parser_OnCompleted(object obj)
        {
           DisplayAlert("Alert", "all works is done", "OK");
        }

        public void ButtonStart_Click(object sender, EventArgs e)
        {
            //           parser.Settings = new OzonSettings(startInt,endInt);

            //           this.BindingContext = new BookViewModel
            {
                parser.Settings = new OzonSettings(OzonBookId.Text);
                parser.Start();
            }
        }

        private void ButtonIsbn_Click(object sender, EventArgs e)
        {
            //           parser.Settings = new OzonSettings(startInt,endInt);

            //           this.BindingContext = new BookViewModel
            {
                parserIsbn.Settings = new AmazonSettings(book_isbn.Text);
                parserIsbn.Start();
            }
        }

        async void adddata(object s, EventArgs args)
        {
            var book = new Book();
            string bookSbbn;

            if (book_category.SelectedIndex == -1)
            {
                await DisplayAlert("Ошибка", "ВЫБЕРИТЕ КАТЕГОРИЮ КНИГИ", "ok");
                return;
            }
            else
            {
                book.BookTitle = book_title.Text;
                book.ISBNnumber = book_isbn.Text;
                book.BookAuthor = book_author.Text;
                book.BookCategory = book_category.Items[book_category.SelectedIndex];
                book.BookDescription = book_description.Text;
                book.BookImagePath = book_cover.Text;
            }

            List<Book> bookList = null;
            bookList = app.Database.SearchBookByIsbn(book.ISBNnumber).ToList();

            if (bookList.Count == 0)
            {
                app.Database.AddBook(book);
               // await DisplayAlert("Data Saved!", "New book '" + book_title.Text + "' has been added to your library!", "OK");
                await Navigation.PushAsync(new NewBookAdded()
                {
                    BookTitle = book_title.Text
                });

            }

            else
            {
                await DisplayAlert("Ошибка", "Книга с таким ISBN уже есть", "ok");
                return;
            }
        }

        async void cancel(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewBookMain());
        }

        async void addimage(object sender, EventArgs args)
        {
            await DisplayAlert("Image!", "New image will be added", "OK");
        }
        void OnTextChanged(object sender, EventArgs e)
        {
            if (book_isbn.Text.Contains("."))
            {
                DisplayAlert("Error", "InCorrect ISBN Number", "ok");
            }
        }
    }
}