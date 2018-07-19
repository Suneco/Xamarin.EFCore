using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.EFCore
{
    public partial class App : Application
    {
        public static readonly string DatabasePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("storage.db");

        public App()
        {
            InitializeComponent();
            InitDatabase();

            MainPage = new MainPage();
        }

        private static void InitDatabase()
        {
            using (var ctx = new DatabaseContext(DatabasePath))
            {
                ctx.Database.EnsureCreated();
                ctx.Database.Migrate();
            }
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
    }
}
