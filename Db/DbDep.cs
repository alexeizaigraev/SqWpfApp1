using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    internal class DbDep : DbBase
    {
        internal static string RefreshFromIndata()
        {
            return RefreshTablePapa("departments", dataInPath + "departments.csv", false);
        }

        internal static string RefreshFromIndataLIte()
        {
            return RefreshTablePapa("departments", dataInPath + "departments.csv", true);
        }

        internal static string SelectDepsToInData()
        {
            return TableToFile("departments", dataInPath + "departments.csv");
        }

        internal static string SelectDepsToGdrive()
        {
            return TableToFile("departments", dbGdrivePath + "departments.csv");
        }

        internal static string SelectDepsToGdriveLog()
        {
            return TableToFile("departments", $"{dbGdrivePath}{DateNowLine()}_departments.csv");
        }

        internal static List<string> GetPartners()
        {
            string query = @"SELECT DISTINCT partner
FROM departments
ORDER BY partner;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetDepList()
        {
            string query = @"SELECT department FROM departments
ORDER BY department;";
            return GetList(query);
        }

        internal static List<string> GetCityTypes()
        {
            string query = @"SELECT DISTINCT city_type FROM departments ORDER BY city_type;";
            return GetListWithEmpty(query);
        }


        internal static List<string> GetStreetTypes()
        {
            string query = @"SELECT DISTINCT street_type FROM departments ORDER BY street_type;";
            return GetListWithEmpty(query);
        }

        internal static List<string> GetOneDepData(string dep)
        {
            string query = $@"SELECT * 
FROM departments
WHERE departments.department = '{dep}';";
            return GetOneData(query);
        }

        internal static string DelDep(string dep)
        {
            string q = $@"DELETE FROM departments
    WHERE department = '{dep}';";
            return DbExec(q);
        }

        internal static string AddDep(string[] vec0)
        {
            var vec = GoodVec(vec0);
            try { DelDep(vec[0]); }
            catch { }
            string q = $@"INSERT INTO departments ({COL_DEPS})
    VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}' , '{vec[19]}');";
            return DbExec(q);
        }

        internal static string AddDep(List<string> vec0)
        {
            var vec = GoodVec(vec0);
            try { DelDep(vec[0]); }
            catch { }
            string q = $@"INSERT INTO departments ({COL_DEPS})
    VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}' , '{vec[19]}');";
            return DbExec(q);
        }

        internal static string UpdateDep(string[] data)
        {
            string q = $@"UPDATE departments SET
    region = '{data[1]}',
    district_region = '{data[2]}',
    district_city = '{data[3]}',
    city_type = '{data[4]}',
    city = '{data[5]}',
    street = '{data[6]}',
    street_type = '{data[7]}',
    hous = '{data[8]}',
    post_index = '{data[9]}',
    partner = '{data[10]}',
    status = '{data[11]}',
    register = '{data[12]}',
    edrpou = '{data[13]}',
    address = '{data[14]}',
    partner_name = '{data[15]}',
    id_terminal = '{data[16]}',
    koatu = '{data[17]}',
    tax_id = '{data[18]}',
    koatu2 = '{data[19]}'
    WHERE department = '{data[0]}';";
            try
            {
                DbExec(q);
                info = $"update {data[0]}";
            }
            catch (Exception ex) { info = ex.Message + "\n"; }
            return info;
        }


        internal static string UpdateDep(List<string> data)
        {
            string q = $@"UPDATE departments SET
    region = '{data[1]}',
    district_region = '{data[2]}',
    district_city = '{data[3]}',
    city_type = '{data[4]}',
    city = '{data[5]}',
    street = '{data[6]}',
    street_type = '{data[7]}',
    hous = '{data[8]}',
    post_index = '{data[9]}',
    partner = '{data[10]}',
    status = '{data[11]}',
    register = '{data[12]}',
    edrpou = '{data[13]}',
    address = '{data[14]}',
    partner_name = '{data[15]}',
    id_terminal = '{data[16]}',
    koatu = '{data[17]}',
    tax_id = '{data[18]}',
    koatu2 = '{data[19]}'
    WHERE department = '{data[0]}';";
            try
            {
                DbExec(q);
                info = $"update {data[0]}";
            }
            catch (Exception ex) { info = ex.Message + "\n"; }
            return info;
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

        internal static string NextDep(string dep)
        {
            string rez = "";
            var vec = GetDepList();
            if (vec.IndexOf(dep) > -1)
            {
                if (vec.IndexOf(dep) < vec.Count - 1)
                    rez = vec[vec.IndexOf(dep) + 1];
                else { rez = vec[0]; }
            }
            else { rez = dep; }
            return rez;
        }

        internal static string PredDep(string dep)
        {
            string rez = "";
            var vec = GetDepList();
            if (vec.IndexOf(dep) > -1)
            {
                if (vec.IndexOf(dep) > 0)
                    rez = vec[vec.IndexOf(dep) - 1];
                else { rez = vec[vec.Count - 1]; }
            }
            else { rez = dep; }
            return rez;
        }

    }
}
