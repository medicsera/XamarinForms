using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinanceManager
{
    public class IncomeMoney
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int incomeMoney { get; set; }

        public string category { get; set; }

    }
}
