using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace FinanceManager
{
    public partial class App : Application
    {

        private static DB_IncomeMoney incomeMoney;

        private static DB_IncomeCategory incomeCategory;
        public static DB_IncomeMoney IncomeMoney
        {
            get
            {
                if (incomeMoney == null)
                {
                    incomeMoney = new DB_IncomeMoney(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db_income_money.sqlite3"));
                }
                return incomeMoney;
            }
        }

        public static DB_IncomeCategory IncomeCategory
        {
            get
            {
                if (incomeCategory == null)
                {
                    incomeCategory = new DB_IncomeCategory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db_income_category.sqlite3"));
                }
                return incomeCategory;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
