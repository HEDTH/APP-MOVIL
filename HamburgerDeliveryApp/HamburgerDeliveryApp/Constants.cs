using System;
using System.Collections.Generic;
using System.Text;

namespace HamburgerDeliveryApp
{
    public static class Constants
    {
        public const string DatabasePath = "userdatabase.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;
    }

}
