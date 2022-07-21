using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbTerm : DbBase
    {
        internal static string RefreshFromIndata()
        {
            return RefreshTablePapa("terminals", dataInPath + "terminals.csv", false);
        }

        internal static string RefreshFromGdrive()
        {
            return RefreshTablePapa("terminals", dbGdrivePath + "terminals.csv", false);
        }

        internal static string RefreshFromIndataLIte()
        {
            return RefreshTablePapa("terminals", dataInPath + "terminals.csv", true);
        }

        internal static string SelectTermsToInData()
        {
            return TableToFile("terminals", dataInPath + "terminals.csv");
        }

        internal static string SelectTermsToGdrive()
        {
            return TableToFile("terminals", dbGdrivePath + "terminals.csv");
        }

        internal static string SelectTermsToGdriveLog()
        {
            return TableToFile("terminals", $"{dbGdrivePath}{DateNowLine()}_terminals.csv");
        }

        internal static List<string> GetSerialList()
        {
            string query = @"SELECT DISTINCT serial_number FROM terminals
ORDER BY serial_number;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetFiscalList()
        {
            string query = @"SELECT DISTINCT fiscal_number FROM terminals
ORDER BY fiscal_number;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetStatusList()
        {
            string query = @"SELECT DISTINCT tickets_arhiv FROM terminals
ORDER BY tickets_arhiv;";
            return GetListWithEmpty(query);
        }


        internal static List<string> GetModelList()
        {
            string query = @"SELECT DISTINCT model FROM terminals
ORDER BY model;";
            return GetListWithEmpty(query);
        }


        internal static List<string> GetOwners()
        {
            string query = @"SELECT DISTINCT owner_rro FROM terminals ORDER BY owner_rro;";
            return GetListWithEmpty(query);
        }


        internal static List<string> GetModels()
        {
            string query = @"SELECT DISTINCT model FROM terminals ORDER BY model;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetSofts()
        {
            string query = @"SELECT DISTINCT soft FROM terminals ORDER BY soft DESC;";
            return GetListWithEmpty(query);
        }


        internal static List<string> GetSeals()
        {
            string query = @"SELECT DISTINCT sealing FROM terminals ORDER BY sealing DESC;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetFiscalActiv()
        {
            string query = @"SELECT DISTINCT fiscal_number FROM terminals
    WHERE tickets_arhiv = 'Активний';";
            return GetList(query);
        }


        internal static List<string> GetLIstActivDep()
        {
            string query = @"SELECT DISTINCT department
FROM terminals
    WHERE tickets_arhiv = 'Активний';";
            return GetList(query);
        }


        internal static List<string> GetLIstNoActivDep()
        {
            string query = @"SELECT DISTINCT department
FROM terminals
    WHERE tickets_arhiv != 'Активний';";
            return GetList(query);
        }


        internal static List<string> GetFiscalBlocked()
        {
            string query = @"SELECT DISTINCT fiscal_number FROM terminals
    WHERE tickets_arhiv != 'Активний';";
            return GetList(query);
        }


        internal static List<string> GetTermListPartner(string partner)
        {
            string query = $@"SELECT termial FROM terminals, departments
    WHERE departments.department = terminals.department
    AND departments.partner = '{partner}'
ORDER BY termial;;";
            return GetList(query);
        }


        internal static string GetAddress(string dep)
        {
            string query = $@"select address from departments WHERE department = '{dep}';";
            return GetOneData(query)[0];
        }

        internal static string GetTaxId(string dep)
        {
            string query = $@"select tax_id from departments WHERE department = '{dep}';";
            return GetOneData(query)[0];
        }

        internal static string GetKoatu(string dep)
        {
            string query = $@"select koatu from departments WHERE department = '{dep}';";
            return GetOneData(query)[0];
        }

        internal static string UpdateTicketsAthiv(string status, string fiscal)
        {
            string query = $@"UPDATE terminals
SET tickets_arhiv = '{status}'
WHERE terminals.fiscal_number = '{fiscal}';";
            return DbExec(query);
        }

        internal static List<string> GetOneTermData(string term)
        {
            string query = $@"SELECT * 
FROM terminals
WHERE terminals.termial = '{term}';";
            return GetOneData(query);
        }

        internal static string SerialToTermOne(string par)
        {
            string query = $@"SELECT termial 
FROM terminals
WHERE serial_number LIKE '%{par}';";
            return GetList(query)[0];
        }


        internal static string FiscalToTermOne(string par)
        {
            string query = $@"SELECT termial 
FROM terminals
WHERE fiscal_number LIKE '%{par}';";
            return GetList(query)[0];
        }

        internal static string DelTerm(string term)
        {
            string q = $@"DELETE FROM terminals
    WHERE termial = '{term}';";
            return DbExec(q);
        }

        internal static string AddTerm(string[] vec0)
        {
            var vec = GoodVec(vec0);
            try { DelTerm(vec[1]); }
            catch { }
            string q = $@"INSERT INTO terminals(
	department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish)
	VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}', '{vec[21]}');";
            return DbExec(q);
        }

        internal static string AddTerm(List<string> vec0)
        {
            var vec = GoodVec(vec0);
            try { DelTerm(vec[1]); }
            catch { }
            string q = $@"INSERT INTO terminals(
	department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish)
	VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}', '{vec[21]}');";
            return DbExec(q);
        }





        internal static string GetKoatu2(string dep)
        {
            string query = $"select city, district_city, koatu from departments WHERE department = '{dep}';";
            var vec = GetOneData(query);
            string city = vec[0];
            string distrCity = vec[1];
            string koatu = vec[2];
            if ("" == city)
                city = "";
            if ("" == distrCity)
                distrCity = "";
            if ("" == koatu)
                koatu = "";
            string rez = "";
            try { rez = DbKoatuSpr.MkKoatu2(city, distrCity, koatu); }
            catch { }
            return rez;
        }

        internal static List<string> GetTermList()
        {
            return GetList(@"SELECT DISTINCT termial 
FROM terminals
ORDER BY termial;");
        }

        internal static string NextTerm(string term)
        {
            string rez = "";
            var vec = GetTermList();
            if (vec.IndexOf(term) > -1)
            {
                if (vec.IndexOf(term) < vec.Count - 1)
                    rez = vec[vec.IndexOf(term) + 1];
                else { rez = vec[0]; }
            }
            else { rez = term; }
            return rez;
        }

        internal static string PredTerm(string term)
        {
            string rez = "";
            var vec = GetTermList();
            if (vec.IndexOf(term) > -1)
            {
                if (vec.IndexOf(term) > 0)
                    rez = vec[vec.IndexOf(term) - 1];
                else { rez = vec[vec.Count - 1]; }
            }
            else { rez = term; }
            return rez;
        }

    }
}
