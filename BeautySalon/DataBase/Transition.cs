using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BeautySalon.DataBase
{
    class Transition
    {
        public static Frame MainFrame { get; set; }

        private static BeautyShopEntities context;
        public static BeautyShopEntities Context
        {
            get
            {
                if (context == null)
                    context = new BeautyShopEntities();

                return context;
            }
        }
    }
}
