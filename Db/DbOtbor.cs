using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbOtbor : DbBase
    {

        internal static string RefreshFromIndata()
        {
            return RefreshTablePapa("otbor", dataInPath + "otbor.csv", false);
        }

        internal static string InsertAllOtbor(List<List<string>> arr)
        {
            return RefreshTableArr("otbor", arr);
        }


        internal static string InsertAllOtbor(List<string[]> arr)
        {
            return RefreshTableArr("otbor", arr);
        }

        internal static string ShowOtbor()
        {
            var rez = "\n";
            var otbor = GetData("SELECT * FROM otbor");
            foreach (var u in otbor)
            {
                rez += $"{u[0]} {u[1]}\n";
            }
            return rez;
        }
    }
}
