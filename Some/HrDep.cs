using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class HrDep : Papa
    {

        //static List<string[]> koatuAll = FileToArr(dataInPath + "koatuall.csv");

        public static void MainHrDep()
        {
            info = "";
            string outText = "№ п/п;№ Відділення ТОВ ЕПС;Область;Район в обл.;Індекс;Тип населеного пункту;Населений пункт;Район в місті;Тип вулиці;Адреса;Номер будинку;Дата признчення керівника;модель РРО;Заводський № РРО;2;koatu1;koatu2\n";
            var data = DbBase.GetData(@"SELECT department, region, district_region, post_index, city_type, city, district_city, street_type, street, hous, address, koatu, koatu2
FROM departments, otbor
WHERE department = dep
ORDER BY department;");
            int count = 0;

            foreach (var line in data)
            {
                string sity = line[5];
                string distrSity = line[6];
                string koatu = line[11];
                string koatu2 = "";
                string q = $@"SELECT koatu2
        FROM koatu_spr
        WHERE koatu_old = '{koatu}'
        AND
        (place = '{sity}'
        OR place = '{distrSity}');";

                try { koatu2 = DbBase.GetList(q)[0]; }
                catch { }

                line[line.Count - 1] = koatu2;

                count += 1;

                var out_line = $"{count}" + ";"
                + line[0] + ";"
                + line[1] + ";"
                + line[2] + ";"
                + line[3] + ";"
                + line[4] + ";"
                + line[5] + ";"
                + line[6] + ";"
                + line[7] + ";"
                + line[8] + ";"
                + line[9] + ";"
                + "" + ";"
                + "" + ";"
                + "" + ";"
                + line[10] + ";"
                + line[11] + ";"
                + line[12];

                outText += out_line + "\n";
                info += $"{line[0]} {koatu2}\n";
            }

            string ofName = Path.Combine(dataOutPath, "hr_new_deps.csv");
            TextToFile(ofName, outText);

        }
    }

}


