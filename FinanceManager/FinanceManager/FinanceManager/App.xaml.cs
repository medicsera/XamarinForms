using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager
{
    public partial class App : Application
    {
        private static DatabaseRepository _database;
        public static DatabaseRepository Database
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "finance.db3");
                    _database = new DatabaseRepository(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            // Инициализация главной страницы
            MainPage = new NavigationPage(new MainPage()) { };
            
        }

        protected override void OnStart()
        {
            // Здесь можно добавить код для выполнения при запуске приложения
            // Например, проверку обновлений или загрузку начальных данных
        }

        protected override void OnSleep()
        {
            // Код для выполнения при сворачивании приложения
            // Например, сохранение состояния
        }

        protected override void OnResume()
        {
            // Код для выполнения при возобновлении работы приложения
            // Например, обновление данных
        }
    }
}