using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace ExtractDifferenceAddress.Utils
{
    public static class DbConnectionUtil
    {

        public static SQLiteConnection GetDbConnection(string dbFilePath)
        {
            return new SQLiteConnection("Data Source=" + dbFilePath);
        }
    }
}
