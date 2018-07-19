using System;
using System.IO;
using Xamarin.EFCore.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Xamarin.EFCore.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, filename);
        }
    }
}
