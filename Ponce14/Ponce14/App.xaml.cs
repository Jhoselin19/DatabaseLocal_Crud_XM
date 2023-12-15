using Ponce14.DataContext;
using Ponce14.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponce14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GetContext().Database.EnsureCreated();
            MainPage = new Views.CompraView();
        }

        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

            return new AppDbContext(DbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
