using BookTime.Data;
using BookTime.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BookTime
{
    public partial class App : Application
    {
        Database database;
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public Database Database
        {
            set
            {
                database = value;
            }
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }
        public int ResumeAtTodoId { get; set; }
    }

}

