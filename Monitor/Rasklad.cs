﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SqWpfApp1
{
    class Rasklad : Papa
    {

        public static List<string> arr = new List<string>();
        static List<List<string>> comonData = DbComonData.GetAllComonData();

        public static void MainRasklad()
        {

            info = "";
            arr = new List<string>();
            string raskladInPath = Path.Combine(dataPath, "rasklad");
            string gDrivePath = FileToVec(Path.Combine(dataConfigPath, "ConfigGdrivePath.txt"))[0];
            string[] files = Directory.GetFiles(raskladInPath);
            foreach (string path in files)
            {
                string[] ps = path.Split('\\');
                string shortFileName = ps[ps.Length - 1];
                string folder = shortFileName.Substring(0, 7);
                string agSign = folder.Substring(0, 3);
                string oldFname = path;

                string lastFolder = Path.Combine(gDrivePath, MkLastFolder(agSign));
                string lastFolderWithFolder = Path.Combine(lastFolder, folder);

                bool LastFolderOk = myFolder(lastFolderWithFolder);

                string fullNewName = Path.Combine(lastFolderWithFolder, shortFileName);
                FileInfo fileInf = new FileInfo(fullNewName);
                if (fileInf.Exists)
                    MyDelete(fullNewName);

                MoveOneFile(oldFname, fullNewName);
                if (shortFileName.IndexOf("_RP_") > -1)
                {
                    string dep = shortFileName.Split('_')[0];
                    if (dep.Length == 7)
                        arr.Add(dep);
                }
            }
        }

        protected static string MkLastFolder(string agSign)
        {
            string rez = "NoData";
            foreach (var line in comonData)
            {
                string sign = line[1];
                string folder = line[4];
                if (agSign == sign)
                {
                    rez = folder;
                    break;
                }
            }
            if (rez == "nodata") Sos("Нет в my_data", agSign);
            return rez;
        }

        private static bool myFolder(string path)
        {
            bool folderOk = false;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists) dirInfo.Create();
                folderOk = true;
            }
            catch { Sos("Не могу создать папку", path); }
            return folderOk;
        }

    }
}
