using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{

    internal class DbBase : Papa
    {
        internal static string COL_DEPS = "department, region, district_region, district_city, city_type, city, street, street_type, hous, post_index, partner, status, register, edrpou, address, partner_name, id_terminal, koatu, tax_id, koatu2";
        internal static string COL_TERMS = "department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish";
        internal static string COL_OTBORS = "term, dep";
        internal static string COL_KOATU_SPRS = "koatu2, koatu_old, place";
        internal static string COL_EKVS = "fiscal, status";
        internal static string COL_COMON_DATAS = "partner, code, kass_owner, email, gdrive, regime, term_owner, term_shablon, soft_version, limit_kass";


        //internal static string conStr = $"Data Source={dataPath}db/drm.db";
        //internal static string conStr = @"Data Source=C:\Users\Alex\Desktop\ЯРЛЫКИ\Data\db\drm.db";
        internal static string conStr = MkConStr();

        internal static string MkConStr()
        {
            string path = Path.Combine(dataPath, "db");
            path = Path.Combine(path, "drm.db");
            return $"Data Source={path}";
        }


        internal static List<List<string>> GetData(string query)
        {
            List<List<string>> arr = new List<List<string>>();
            using (var connection = new SqliteConnection(conStr))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        List<string> vec = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            { vec.Add(reader[i].ToString()); }
                            catch { }
                        }
                        arr.Add(vec);
                    }
                }
            }
            return arr;
        }


        internal static List<string> GetOneData(string query)
        {
            return GetData(query)[0];
        }

        internal static List<string> GetList(string query)
        {
            List<string> rez = new List<string>();
            foreach (var vec in GetData(query))
            {
                rez.Add(vec[0]);
            }
            return rez;
        }

        internal static List<string> GetListWithEmpty(string query)
        {
            List<string> rez = new List<string>();
            rez.Add("");
            foreach (var vec in GetData(query))
            {
                rez.Add(vec[0]);
            }
            return rez;
        }

        internal static string DbExec(string sql)
        {
            int count = 0;
            using (var connection = new SqliteConnection(conStr))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                count = command.ExecuteNonQuery();
            }
            return $"{count}";
        }

        internal static string ClearTable(string tableName)
        {
            string rez = DbExec($"DELETE FROM {tableName};");
            return rez;
        }

        internal static string VecToQuery(List<string> vec)
        {
            for (int i = 0; i < vec.Count; i++)
            {
                vec[i] = $"'{vec[i]}'";
            }
            return String.Join(",", vec);
        }


        internal static string VecToQuery(string[] vec)
        {
            for (int i = 0; i < vec.Length; i++)
            {
                vec[i] = $"'{vec[i]}'";
            }
            return String.Join(",", vec);
        }

        internal static string RefreshTablePapa(string tableName, string fname, bool flagLite = true)
        {
            int count = -1;
            string columns = "";
            List<string> myList = new List<string>();
            if (tableName == "departments")
            {
                columns = COL_DEPS;
                if (flagLite)
                    myList = GetList("SELECT department FROM departments");
            }

            else if (tableName == "terminals")
            {
                columns = COL_TERMS;
                if (flagLite)
                    myList = GetList("SELECT termial FROM terminals");
            }

            else if (tableName == "otbor")
                columns = COL_OTBORS;
            else if (tableName == "koatu_spr")
                columns = COL_KOATU_SPRS;
            else if (tableName == "ekv")
                columns = COL_EKVS;
            else if (tableName == "comon_data")
                columns = COL_COMON_DATAS;

            if (!flagLite)
                ClearTable(tableName);

            string inf = "";

            //int q_err = 0;
            var arr = FileToArr(fname);

            using (var connection = new SqliteConnection(conStr))
            {
                connection.Open();
                foreach (var line in arr)
                {
                    count += 1;
                    if (count < 1) continue;
                    var command = connection.CreateCommand();

                    var vec = GoodVec(line);
                    if (flagLite && myList != null && myList.Count > 0)
                    {
                        if (tableName == "departments")
                        {
                            if (myList.IndexOf(vec[0]) > -1)
                            {
                                inf += $"pass {vec[0]}\n";
                                continue;
                            }
                        }

                        if (tableName == "terminals")
                        {
                            if (myList.IndexOf(vec[1]) > -1)
                            {
                                inf += $"pass {vec[1]}\n";
                                continue;
                            }
                        }
                    }

                    string sql = $@"INSERT INTO {tableName} (
                    {columns}
                    )
                    VALUES({VecToQuery(vec)});";

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }

            }
            return $"insert {tableName} {count}\n";
        }




        internal static string RefreshTableArr(string tableName, List<List<string>> arr)
        {
            int count = 0;
            string columns = "";
            if (tableName == "departments")
            {
                columns = COL_DEPS;
            }

            else if (tableName == "terminals")
            {
                columns = COL_TERMS;
            }

            else if (tableName == "otbor")
                columns = COL_OTBORS;
            else if (tableName == "koatu_spr")
                columns = COL_KOATU_SPRS;
            else if (tableName == "ekv")
                columns = COL_EKVS;
            else if (tableName == "comon_data")
                columns = COL_COMON_DATAS;

            ClearTable(tableName);

            string inf = "";

            //int q_err = 0;
            
            using (var connection = new SqliteConnection(conStr))
            {
                connection.Open();
                foreach (var line in arr)
                {
                    var command = connection.CreateCommand();

                    var vec = GoodVec(line);
                    
                    string sql = $@"INSERT INTO {tableName} (
                    {columns}
                    )
                    VALUES({VecToQuery(vec)});";

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    count += 1;
                }

            }
            return $"insert {tableName} {count}\n";
        }


        internal static string RefreshTableArr(string tableName, List<string[]> arr)
        {
            int count = 0;
            string columns = "";
            if (tableName == "departments")
            {
                columns = COL_DEPS;
            }

            else if (tableName == "terminals")
            {
                columns = COL_TERMS;
            }

            else if (tableName == "otbor")
                columns = COL_OTBORS;
            else if (tableName == "koatu_spr")
                columns = COL_KOATU_SPRS;
            else if (tableName == "ekv")
                columns = COL_EKVS;
            else if (tableName == "comon_data")
                columns = COL_COMON_DATAS;

            ClearTable(tableName);

            string inf = "";

            //int q_err = 0;

            using (var connection = new SqliteConnection(conStr))
            {
                connection.Open();
                foreach (var line in arr)
                {
                    var command = connection.CreateCommand();

                    var vec = GoodVec(line);

                    string sql = $@"INSERT INTO {tableName} (
                    {columns}
                    )
                    VALUES({VecToQuery(vec)});";

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    count += 1;
                }

            }
            return $"insert {tableName} {count}\n";
        }


        internal static string TableToFile(string tName, string fName)
        {
            string text = "";
            string inf = "";
            if (tName == "departments")
                text = "department;region;district_region;district_city;city_type;city;street;street_type;hous;post_index;partner;status;register;edrpou;address;partner_name;id_terminal;koatu;tax_id;koatu2\n";
            else if (tName == "terminals")
                text = "department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;register;finish\n";
            else if (tName == "ekv") ;
            text = "fiscal;status\n";

            var rows = GetData($"SELECT * FROM {tName};");

            foreach (var vec in rows)
            {
                text += String.Join(";", vec) + "\n";
            }
            TextToFile(text, fName);
            inf += fName + "\n";
            return inf;
        }


    }
}
