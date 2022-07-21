using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborDepAllTerm : Papa
    {
        internal static void MainOtborDepAllTerm()
        {
            string fName = Path.Combine(dataInPath, "otbor_term.csv");
            try
            {
                Process newProc = Process.Start("notepad.exe", fName);
                newProc.WaitForExit();
                newProc.Close(); // освободить выделенные ресурсы
            }
            catch { Sos("Err Open Notepad", fName); }

            List<List<string>> outVec = new List<List<string>>();
            List<string> keys = new List<string>();
            var count = 0;
            var arr = FileToVec(fName);

            foreach (var dep0 in arr)
            {
                if (dep0 == "") continue;
                string dep = dep0.Trim();

                if (keys.Contains(dep)) { continue; }

                foreach (List<string> unit in GetTermsOnDep(dep))
                {
                    var tt = unit[0];
                    var dd = unit[1];
                    keys.Add(dd);
                    var vec = new List<string>();
                    vec.Add(tt);
                    vec.Add(dd);
                    outVec.Add(vec);
                    count++;
                }
            }

            DbOtbor.InsertAllOtbor(outVec);
            info = $"{count}";
        }

        public static List<List<string>> GetTermsOnDep(string dep)
        {
            return DbBase.GetData($@"SELECT termial, department 
FROM terminals
WHERE department = '{dep}'
ORDER BY termial;");

        }
    }
}
