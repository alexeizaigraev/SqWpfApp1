using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class TermToFile : DocPapaBack
    {
        internal static void MainTermToFile()
        {
            var data = DbBase.GetData("SELECT * FROM terminals;");

            string head = "department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;register;finish";

            string fName = "terminals.csv";

            MainDocPapaBack(data, head, fName);

        }




    }
}
