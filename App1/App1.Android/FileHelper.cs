using System;
using System.IO;
using App1.Droid;
using App1.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace App1.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilepath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
