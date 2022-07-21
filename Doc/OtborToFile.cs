using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborToFile : DocPapaBack
    {

        internal static void MainOtborToFile()
        {
            var data = DbBase.GetData("SELECT * FROM otbor;");

            string head = "term;dep";

            string fName = "otbor.csv";

            MainDocPapaBack(data, head, fName);

        }
    }

}