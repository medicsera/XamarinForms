using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinanceManager
{
    public class DB
    {

        private readonly SQLiteConnection conn;

        public DB(string path)
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
}
