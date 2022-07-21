using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DocPapaActiv : Papa
    {
        internal static void MainDocPapaActiv(List<List<string>> data, bool flagActiv)
        {
            //var fiscalActiv = DbTerm.GetLIstActivDep();
            string docPath = Path.Combine(dataOutPath, "DOC");
            var activDeps = DbTerm.GetLIstNoActivDep();
            var noActivDeps = DbTerm.GetLIstNoActivDep();
            string head = "№ п/п;№ відділення ТОВ«ЕПС»;Адреса відділення; ЗН;ФН;Дата";
            info = head + "\n";
            int count = 0;

            foreach (var line in data)
            {
                string dep = line[0];
                string fiscal = line[3];
                if (flagActiv)
                {
                    if (activDeps.IndexOf(dep) > -1)
                        continue;
                }

                else
                {
                    if (noActivDeps.IndexOf(dep) > -1)
                        continue;
                }
                count += 1;
                info += $"{count};{String.Join(";", line)};{DateNowNormal()}\n";

                if (flagActiv)
                { DbTerm.UpdateTicketsAthiv("Активний", fiscal); }
                else
                { DbTerm.UpdateTicketsAthiv("Заблокований", fiscal); }
            }

            string fOut = Path.Combine(docPath, "Activaciya.csv");
            TextToFile(fOut, info);

        }
    }
}
