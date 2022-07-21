using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class OtborPartner : Papa
    {
        internal static void MainOtborPartner(string partnerChoise)
        {

            List<List<string>> outVec = new List<List<string>>();
            List<string> keys = new List<string>();
            var count = 0;
            var arr = GetTermDepOnPartner(partnerChoise);
            foreach (var item in arr)
            {
                string term = item[0];
                if (term == "") continue;

                if (keys.Contains(term)) { continue; }
                else
                {
                    keys.Add(term);
                    outVec.Add(item);
                    count++;
                }

            }

            DbOtbor.InsertAllOtbor(outVec);
            info = $"{count}";
        }

        public static List<List<string>> GetTermDepOnPartner(string parStr)
        {
            return DbBase.GetData($@"SELECT termial, department 
FROM terminals, departments
WHERE terminals.department = departments.department
AND departments.partner = '{parStr}'
ORDER BY terminals.termial; ");
        }
    }
}
