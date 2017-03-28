using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiFi_Sign.Class
{
    class Config
    {

        public static string DbFile { get { return "settings.db"; } set { ; } }
        public static string AdDbFile { get { return "attendance.db"; } set {; } }
        public static string NoName { get { return "[未登记]"; } set {; } }

        public static int OffTime { get { return 5; } set { OffTime = value; } } // 判定离开时间，单位：分钟
        public static int SaveTime { get { return 10; } set { SaveTime = value; } } // 报表保存时间，单位：分钟

    }
}
