using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLoader.Host
{
    public class FileManager
    {
        private static readonly FileManager instance = new FileManager();

        public string Name { get; private set; }

        private FileManager()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static FileManager GetInstance()
        {
            return instance;
        }

        public string[] GetFiles(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return Directory.GetFiles(path);
        }

        public string GetFileExtension(string path)
        {
            var fi = new FileInfo(path);
            if (fi.Exists)
                return fi.Extension.ToUpper();

            return null;
        }

        public void Delete(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
}
