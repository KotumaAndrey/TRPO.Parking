using System;
using System.IO;
using TRPO.Parking.MobileApp;
using TRPO.Parking.Utilitas.Pathfinder;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFilePathfinder))]
namespace TRPO.Parking.MobileApp
{
    internal class AndroidFilePathfinder : IPathfinder
    {
        public string GetPath(string fileName)
        {
            var specialFolder = Environment.SpecialFolder.Personal;
            var folderPath = Environment.GetFolderPath(specialFolder);
            var path = Path.Combine(folderPath, fileName);
            return path;
        }
    }
}
