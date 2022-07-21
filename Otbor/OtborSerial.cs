using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborSerial : PapaOtbor
    {
        internal static void MainOtborSerial()
        {
            List<List<string>> list = new List<List<string>>();
            string fName = Path.Combine(dataInPath, "otbor_serial.csv");
            delegateQuery myDelegate = new delegateQuery(GetTermDepOnSerial);
            MainPapaOtbor(myDelegate, fName);
        }

        public static List<List<string>> GetTermDepOnSerial(string parStr)
        {
            return DbBase.GetData($@"SELECT termial, department FROM terminals WHERE serial_number LIKE '%{parStr}';");
        }
    }
}
