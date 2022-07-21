using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbComonData : DbBase
    {
        internal static Dictionary<string, string> ComonDataDict(int colKeyNum)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var line in GetData("SELECT * FROM comon_data;"))
            {
                dict[line[1]] = line[colKeyNum];
            }
            return dict;
        }

        internal static List<List<string>> GetAllComonData()
        {
            return GetData("SELECT * FROM comon_data;");
        }


        internal static string EkvFromGdrive()
        {
            return RefreshTablePapa("ekv", dbGdrivePath + "ekv.csv", false);
        }

        internal static string EkvFromInData()
        {
            return RefreshTablePapa("ekv", dataInPath + "ekv.csv", false);
        }



    }
}
