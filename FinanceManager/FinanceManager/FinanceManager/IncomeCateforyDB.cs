using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinanceManager
{
    public class IncomeCategoryDB
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string income_category { get; set; }
    }
}
