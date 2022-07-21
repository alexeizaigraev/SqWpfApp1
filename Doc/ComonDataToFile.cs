using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class ComonDataToFile : DocPapaBack
    {
        internal static void MainComonDataToFile()
        {
            var data = DbBase.GetData("SELECT * FROM comon_data;");

            string head = "partner;code;kass_owner;email;gdrive;regime;term_owner;term_shablon;soft_version;limit_kass";

            string fName = "comon_data.csv";

            MainDocPapaBack(data, head, fName);

        }

    }
}
