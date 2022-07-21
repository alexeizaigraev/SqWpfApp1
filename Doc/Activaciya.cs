using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class Activaciya : Papa
    {
        internal static void MainActivaciya()
        {

            ClearInfo();
            var data = GetData();
            DocPapaActiv.MainDocPapaActiv(data, true);
        }

        private static List<List<string>> GetData()
        {
            return DbBase.GetData(@"SELECT terminals.department, departments.address,
        terminals.serial_number, terminals.fiscal_number
        FROM terminals, departments, otbor
        WHERE terminals.termial = otbor.term
        AND departments.department = otbor.dep;");
        }
    }
}
