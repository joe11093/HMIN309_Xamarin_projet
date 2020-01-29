using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Xamarin_projet
{
    class Constants
    {
        public static string BaseAddress = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        public const string DatabaseFilename = "MessagesSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

    }

}
