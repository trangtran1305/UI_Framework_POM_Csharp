using Assignment02.reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment02.actions.commons
{
    class FolderPath
    {          
        public static string CreateFolder(string folderPath)
        {           
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            if (!directory.Exists)
            {
                directory.Create();              
            }
            return folderPath;

        }
        public static void DeleteFolder(string folderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            if (directory.Exists)
            {
                directory.Delete();
            }

        }
}
}
