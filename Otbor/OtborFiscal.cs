using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborFiscal : PapaOtbor
    {
        internal static void MainOtborFiscal()
        {
            List<List<string>> list = new List<List<string>>();
            string fName = Path.Combine(dataInPath, "otbor_fiscal.csv");
            delegateQuery myDelegate = new delegateQuery(GetTermDepOnFiscal);
            MainPapaOtbor(myDelegate, fName);
        }

        public static List<List<string>> GetTermDepOnFiscal(string fiscal)
        {
            return DbBase.GetData($@"SELECT termial, department FROM terminals WHERE fiscal_number LIKE '%{fiscal}';");
        }
    }
}
