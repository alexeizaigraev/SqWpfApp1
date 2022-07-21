using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    class GetRp : Papa
    {
        internal static void MainGetRp()
        {
            var folderHash = MkComonHash(4);
            var otbor = DbBase.GetList("SELECT dep FROM otbor;");
            foreach (var unit in otbor)
            {

                var dep = unit;
                var agSign = dep.Substring(0, 3);
                var folderAgent = folderHash[agSign];
                var folder = Path.Combine(gDrivePath, folderAgent);
                var folderFull = Path.Combine(folder, dep);
                /*
                try {  CoperRp(folderFull, kabinetPath); }
                catch { }
                try { CoperRp(folderFull, "R:/DRM/ЗАИГРАЕВ ОБМЕН АРХИВ/Архив/"); }
                catch { }
                */
                try { CoperRp(folderFull, kabinetPath); }
                catch { }


                //SayBlue(agSign);
            }
        }
    }
}
