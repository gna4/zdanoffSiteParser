using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitesParser.BL.Interfaces;
using System.IO;

namespace SitesParser.BL.Services
{
    public class FileManager : IDataService
    {
        public bool SaveShops(List<string> shops)
        {
            string content = shops.Aggregate((i, j) => i + "\n" + j);
            SaveToFile(FilePath, content);
            return true;
        }

        private void SaveToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public string FilePath { get; set; }
    }
}
