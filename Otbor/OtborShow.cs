using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborShow : Papa
    {
        internal static void MainOtborShow()
        {
            ClearInfo();
            info = DbOtbor.ShowOtbor();
        }
    }
}
