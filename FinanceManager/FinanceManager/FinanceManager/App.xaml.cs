using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                    incomeMoney = new DB_IncomeMoney("db_income_money.sqlite");
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
                    incomeCategory = new DB_IncomeCategory("db_income_category.sqlite");
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
