using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class EkvGroup : Papa
    {

        internal static void MainEkvGroup()
        {
            info = "партнёр;статус;собственник;аренда;количество\n";
            var data = GetData();
            foreach (var line in data)
            {
                info += String.Join(";", line) + "\n";
            }

            info += "\n________________\n";

            data = GetBigData();

            Dictionary<string, int> dicActiv = new Dictionary<string, int>();
            Dictionary<string, int> dicBlock = new Dictionary<string, int>();
            //Dictionary<string, int> dicAll = new Dictionary<string, int>();

            foreach (string partner in DbBase.GetList(@"SELECT DISTINCT partner
FROM departments
ORDER BY partner;"))
            {
                if (partner == "") continue;
                dicActiv[partner] = 0;
                dicBlock[partner] = 0;
                foreach (var line in data)
                {
                    if (line[0] == partner)
                    {
                        if (line[5] == "Активний")
                        {
                            dicActiv[partner]++;
                        }
                        else
                        {
                            dicBlock[partner]++;
                        }
                    }


                }
                //info += "\n";
                info += $"{partner}\n";
                info += $"Активные: ;{dicActiv[partner]}\n";
                info += $"Не Активные: ;{dicBlock[partner]}\n";
                info += $"Всего: ;{dicActiv[partner] + dicBlock[partner]}\n";
                info += "\n________________\n";

            }



            info += "\n________________\n";
            info += "партнёр;терминал;отделение;ЗН;ФН;статус;собственник;аренда;область;город;адрес;едрпоу\n";


            foreach (var line in data)
            {
                info += String.Join(";", line) + "\n";
            }

            string fName = Path.Combine(dataOutPath, "DOC");
            fName = Path.Combine(fName, "EkvGroup.csv");
            TextToFile(fName, info);
        }


        static List<List<string>> GetBigData()
        {
            List<List<string>> outList = new List<List<string>>();
            string q = @"SELECT departments.partner,
	terminals.termial, terminals.department,
	terminals.serial_number, terminals.fiscal_number,
	terminals.tickets_arhiv, terminals.owner_rro,
    terminals.sealing,
	departments.region, departments.city, departments.address,
    departments.edrpou
FROM terminals, departments
WHERE departments.department = terminals.department
ORDER BY terminals.termial;
";
            return DbBase.GetData(q);
        }

        static List<List<string>> GetData()
        {
            List<List<string>> outList = new List<List<string>>();
            string q = @"SELECT d.partner, t.tickets_arhiv, t.owner_rro, t.sealing, count(*  )
FROM departments d, terminals t
WHERE d.department = t.department
AND t.tickets_arhiv IS NOT NULL
AND t.tickets_arhiv != ''
GROUP BY d.partner, t.tickets_arhiv, t.owner_rro, t.sealing
ORDER BY d.partner, t.tickets_arhiv, t.owner_rro, t.sealing;
";
            var data = DbBase.GetData(q);

            foreach (var line in data)
            {
                List<string> newLine = new List<string>();
                foreach (var u in line)
                {
                    newLine.Add(u.ToString());
                }
                outList.Add(newLine);
            }

            return outList;
        }

    }


}
