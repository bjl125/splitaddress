using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite.Generic;
using System.Data.SQLite.Linq;
using System.Data.SQLite;
using System.Data;

namespace AddressSplitForExcel.Entity
{
    public class SQLiteContexts : DbContext
    {
        public SQLiteContexts(string conStr = "configdb") : base(conStr)
        {

        }
        public SQLiteContexts(SQLiteConnection conn) : base(conn, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<SenderAddressInfo> SenderAddressInfo { set; get; }
    }
}
