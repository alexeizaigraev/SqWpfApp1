using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborAddChoiseTerm : Papa
    {
        internal static void MainOtborAddChoiseTerm(List<string> choise)
        {
            
            List<List<string>> outVec = new List<List<string>>();
            List<string> keys = new List<string>();
            var count = 0;
            
            foreach (var item in choise)
            {
                if (item == "") continue;
                string term = item.Trim();
                if (term == "") continue;

                if (keys.Contains(term)) { continue; }
                else
                {
                    
                    keys.Add(term);
                    var tt = term;
                    var dd = term.Substring(0, 7);
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
    }
}
