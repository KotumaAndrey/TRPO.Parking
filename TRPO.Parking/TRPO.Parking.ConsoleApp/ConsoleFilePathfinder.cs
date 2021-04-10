using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.ConsoleApp
{
    internal class ConsoleFilePathfinder : IPathfinder
    {
        public string GetPath(string fileName)
        {
            var specialFolder = Environment.SpecialFolder.Personal;
            var folderPath = Environment.GetFolderPath(specialFolder);
            var path = Path.Combine(folderPath, fileName);
            return fileName;
        }
    }
}
