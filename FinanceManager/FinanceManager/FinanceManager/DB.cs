using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinanceManager
{
    public class DB_IncomeMoney
    

    {

        private readonly SQLiteConnection conn;

        public DB_IncomeMoney(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<IncomeMoney>();
        }

        public List<IncomeMoney> GetIncomeMoney()
        {
            return conn.Table<IncomeMoney>().ToList();
        }

        public int SaveIncomeMoney(IncomeMoney incomeMoney)
        {
            return conn.Insert(incomeMoney);
        }
    }
    public class DB_IncomeCategory
    {
        private readonly SQLiteConnection conn;

        public DB_IncomeCategory(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<IncomeCategoryDB>();
        }

        public List<IncomeCategoryDB> GetIncomeCategory()
        {
            return conn.Table<IncomeCategoryDB>().ToList();
        }

        public int SaveIncomeCategory(IncomeCategoryDB incomeCategory)
        {
            return conn.Insert(incomeCategory);
        }

    }
}
