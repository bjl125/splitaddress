using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AddressSplitForExcel.Entity
{
    public static class SQLiteConfig
    {
        public static string SQLiteConnectionString()
        {
            SQLiteConnectionStringBuilder str = new SQLiteConnectionStringBuilder()
            {
                DataSource = @"D:\MyProject\AddressSplitForExcel\splitaddress\AddressSplitForExcel\configdata.db",
                
            };

            return str.ConnectionString;
        }

        public static SQLiteConnection SQLiteConnection()
        {
            SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source=D:\MyProject\AddressSplitForExcel\splitaddress\AddressSplitForExcel\configdata.db;");

            return conn;
        }
    }
}
