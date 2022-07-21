using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbEkv : DbBase
    {

        internal static string RefreshFromIndata()
        {
            return RefreshTablePapa("ekv", dataInPath + "ekv.csv", false);
        }

    }
}
