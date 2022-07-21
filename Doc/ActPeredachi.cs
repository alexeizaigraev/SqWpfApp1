using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class ActPeredachi : DocPapa
    {
        internal static void MainActPeredachi()
        {
            var data = GetData();

            string head = "№ п/п;Найменування устаткування, Реєстратор контрольно-касовий електронний чорний;Серійний Номер;Відділення ТОВ \"ЕПС\";Місце розташування підприємства торгівлі-послуг;Кількість оди-ниць;Вартість з ПДВ (грн.)";

            string fName = "Act_Peredachi.csv";

            MainDocPapa(data, head, fName);
        }

        private static List<List<string>> GetData()
        {
            return DbBase.GetData(@"SELECT terminals.model, terminals.serial_number, 
        terminals.department, departments.address
        FROM terminals, departments, otbor
        WHERE terminals.termial = otbor.term
        AND departments.department = otbor.dep;");
        }
    }
}
