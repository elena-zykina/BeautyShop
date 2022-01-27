using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DataBase
{
    class ProductObj
    {
        public static int ID { get; set; }
        public static string Title { get; set; }
        public static decimal Cost { get; set; }
        public static string MainImagePath { get; set; }
        public static int ManufacturerID { get; set; }
        public static bool IsActive { get; set; }
    }
}
