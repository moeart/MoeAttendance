using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WiFi_Sign.Class
{
    class DataBase
    {
        public static void Create(string FileName)
        {
            SQLiteConnection.CreateFile(FileName);
        }


        public static int Excute(string FileName, string SqlCommand)
        {
            try
            {
                SQLiteConnection Db = new SQLiteConnection("Data Source=" + FileName + ";Version=3;");

                Db.Open();
                SQLiteCommand command = new SQLiteCommand(SqlCommand, Db);

                int Ret = command.ExecuteNonQuery();
                Db.Close();
                return Ret;
            }
            catch
            {
                return -1;
            }
        }


        public static string QueryOnce(string FileName, string SqlCommand, int StrIndex)
        {
            try
            {
                string Ret = string.Empty;
                SQLiteConnection Db = new SQLiteConnection("Data Source=" + FileName + ";Version=3;");

                Db.Open();
                SQLiteCommand command = new SQLiteCommand(SqlCommand, Db);
                SQLiteDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Ret = Reader.GetString(StrIndex);
                }

                Db.Close();
                return Ret;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
