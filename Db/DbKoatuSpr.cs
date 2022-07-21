using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbKoatuSpr : DbBase
    {
        internal static string MkKoatu2(string city, string distrCity, string koatu)
        {
            string rez = "";
            string q = $@"SELECT koatu2
    FROM koatu_spr
    WHERE koatu_old = '{koatu}'
    AND(
    place = '{city}'
    OR place = '{distrCity}'
    );";
            try { rez = GetOneData(q)[0]; }
            catch { }
            return rez;
        }
    }
}
